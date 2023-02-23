using System;
using CodeBase.Infrastructure.Services.StaticData;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        
        private Vector3 _nextPointPosition;
        private int _currentPointIndex;
        private bool _enemiesDefeated;
        private bool _isMoving;
        private IStaticDataService _staticData;

        public event Action WayPointReached;
        public event Action Finished;

        public void Construct(IStaticDataService staticData) => 
            _staticData = staticData;

        private void Start()
        {
            _enemiesDefeated = true;
        
            ChangeWayPoint();
        }

        private void Update()
        {
            if (CanMove())
                _agent.destination = _nextPointPosition;

            else if (IsPointReached())
            {
                _isMoving = false;
                _enemiesDefeated = false;
                _agent.enabled = false;

                if (AllPointsFinished() == false)
                {
                    WayPointReached?.Invoke();

                    ChangeWayPoint();
                }
                else
                {
                    Finished?.Invoke();
                }
            }
        }

        public void MoveStateOn()
        {
            _agent.enabled = true;
            _isMoving = true;
            _enemiesDefeated = true;
        }

        public void MoveStateOff() => _isMoving = false;

        private bool AllPointsFinished() =>
            _currentPointIndex >= _staticData.GetAllWayPointsData().AllWayPointsWithEnemies.Count - 1;

        private void ChangeWayPoint()
        {
            _currentPointIndex++;

            UpdateWayPoint(id: _currentPointIndex);
        }

        private bool CanMove() =>
            _isMoving && _enemiesDefeated && _nextPointPosition != Vector3.zero && IsPointReached() == false;

        private void UpdateWayPoint(int id) => 
            _nextPointPosition = _staticData.GetAllWayPointsData().AllWayPointsWithEnemies[index: id].At;

        private bool IsPointReached() =>
            Vector3.Distance(a: _agent.transform.position, b: _nextPointPosition) < 0.35f;
    }
}
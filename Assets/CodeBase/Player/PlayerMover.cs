using System;
using CodeBase.Infrastructure.Services.LevelPath;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;

        private ILevelPathService _levelPathService;
        private Vector3 _nextPointPosition;
        private bool _enemiesAtPointDefeated;
        private bool _isMoving;

        public float Velocity => _agent.velocity.magnitude;

        public float SpeedAgent
        {
            get => _agent.speed;
            set => _agent.speed = value;
        } 

        public event Action WayPointReached;

        public void Construct(ILevelPathService levelPathService) =>
            _levelPathService = levelPathService;

        private void Start() => 
            _enemiesAtPointDefeated = true;

        private void Update()
        {
            if (CanMove())
                _agent.destination = _nextPointPosition;

            else if (IsPointReached())
            {
                _isMoving = false;
                _enemiesAtPointDefeated = false;
                _agent.enabled = false;

                WayPointReached?.Invoke();
            }
        }

        public void MoveStateOn()
        {
            _agent.enabled = true;
            _isMoving = true;
            _enemiesAtPointDefeated = true;

            ChangeWayPoint();
        }

        public void MoveStateOff() => _isMoving = false;

        private void ChangeWayPoint()
        {
            _levelPathService.CurrentPointNumber++;

            UpdateWayPoint(id: _levelPathService.CurrentPointNumber);
        }

        private bool CanMove() =>
            _isMoving && _enemiesAtPointDefeated && _nextPointPosition != Vector3.zero && IsPointReached() == false;

        private void UpdateWayPoint(int id) =>
            _nextPointPosition = _levelPathService.WayPointPosition(id);

        private bool IsPointReached() =>
            Vector3.Distance(a: _agent.transform.position, b: _nextPointPosition) < 0.35f; //AAA
    }
}
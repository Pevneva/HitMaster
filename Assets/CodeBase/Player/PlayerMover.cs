using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private WayPoint _nextPoint;
        [SerializeField] private NavMeshAgent _agent;
        
        private void Update()
        {
            if (IsPointReached() == false)
                _agent.destination = _nextPoint.transform.position;
        }

        private bool IsPointReached() => 
            Vector3.Distance(_agent.transform.position, _nextPoint.transform.position) < Constants.Epsilon;
    }
}
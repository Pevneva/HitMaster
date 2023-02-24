using UnityEngine;

namespace CodeBase.Logic
{
    public class RigidBodySetter : MonoBehaviour
    {
        private Rigidbody[] _rigidBodies;

        private void Start()
        {
            _rigidBodies = GetComponentsInChildren<Rigidbody>();

            TurnOnKinematic();
        }

        public void TurnOnKinematic()
        {
            foreach (Rigidbody rigidBody in _rigidBodies) 
                rigidBody.isKinematic = true;
        }
    
        public void TurnOffKinematic()
        {
            foreach (Rigidbody rigidBody in _rigidBodies)
            {
                rigidBody.velocity = Vector3.zero;
                rigidBody.isKinematic = false;
            }
        }
    }
}

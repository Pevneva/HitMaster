using UnityEngine;

namespace CodeBase.Enemy
{
    public class RotateToPlayer : MonoBehaviour
    {
        public float Speed { get; set; }

        private Transform _playerTransform;
        private Vector3 _positionToLook;

        private void Update() => 
            RotateTowardsHero();

        public void Construct(Transform playerTransform) => 
            _playerTransform = playerTransform;

        private void RotateTowardsHero()
        {
            UpdatePositionToLook();

            transform.rotation = SmoothedRotation(transform.rotation, _positionToLook);
        }

        private void UpdatePositionToLook()
        {
            Vector3 positionDiff = _playerTransform.position - transform.position;
            _positionToLook = new Vector3(positionDiff.x, 0, positionDiff.z);
        }

        private Quaternion SmoothedRotation(Quaternion rotation, Vector3 position) => 
            Quaternion.Lerp(rotation, TargetRotation(position), SpeedFactor());

        private static Quaternion TargetRotation(Vector3 position)
            => Quaternion.LookRotation(position);

        private float SpeedFactor() => 
            Speed * Time.deltaTime;
    }
}
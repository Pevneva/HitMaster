using UnityEngine;

namespace CodeBase.Bullet
{
    public class BulletMover : MonoBehaviour
    {
        [SerializeField] private float _speed = 8;

        private Vector3 _direction;

        public void Construct(Vector3 direction) => 
            _direction = direction;

        private void Update()
        {
            if (_direction.magnitude > Constants.Epsilon)
                transform.Translate(_direction * (Time.deltaTime * _speed));
        }
    }
}
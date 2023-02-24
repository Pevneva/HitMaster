using UnityEngine;

namespace CodeBase.Bullet
{
    public class BulletMover : MonoBehaviour
    {
        private Vector3 _direction;
        
        public float Speed { get; set; }

        public void Construct(Vector3 direction) => 
            _direction = direction;

        private void Update()
        {
            if (_direction.magnitude > Constants.Epsilon)
                transform.Translate(_direction * (Time.deltaTime * Speed));
        }
    }
}
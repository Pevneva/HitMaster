using CodeBase.Enemy;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Bullet
{
    public class BulletAttack : MonoBehaviour
    {
        private Transform _playerTransform;

        public float Damage { get; set; }

        public void Construct(Transform player) =>
            _playerTransform = player;

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.parent.transform.TryGetComponent(out EnemyHealth health))
                health.TakeDamage(Damage);

            ReturnToPool();
        }

        private void OnCollisionEnter(Collision other) => ReturnToPool();

        private void ReturnToPool()
        {
            gameObject.SetActive(false);
            transform.parent = _playerTransform;
        }
    }
}
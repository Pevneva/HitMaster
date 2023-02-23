using System;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _health;

        private const float DeathTime = 0.7f;

        public event Action Happened;

        private void Start() =>
            _health.HealthChanged += CheckDeath;

        private void OnDestroy()
        {
            if (_health != null)
                _health.HealthChanged -= CheckDeath;
        }

        private void CheckDeath()
        {
            if (_health.Current <= 0)
                Die();
        }

        private void Die()
        {
            _health.HealthChanged -= CheckDeath;

            Happened?.Invoke();
            Invoke(nameof(DestroyEnemy), DeathTime);
        }

        private void DestroyEnemy() =>
            Destroy(gameObject);
    }
}
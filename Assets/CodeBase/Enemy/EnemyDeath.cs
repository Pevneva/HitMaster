using System;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _health;
        [SerializeField] private RigidBodySetter _rigidBodySetter;

        // private const float DeathTime = 1.7f; AAA
        public float DeathTime { get; set; }

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
            
            _rigidBodySetter.TurnOffKinematic();

            Happened?.Invoke();
            Invoke(nameof(DestroyEnemy), DeathTime);
        }

        private void DestroyEnemy() =>
            Destroy(gameObject);
    }
}
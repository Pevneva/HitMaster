using System;

namespace CodeBase.Enemy
{
    public interface IEnemyHealth
    {
        event Action HealthChanged;
        float Current { get; set; }
        float Max { get; set; }
        void TakeDamage(float damage);
    }
}
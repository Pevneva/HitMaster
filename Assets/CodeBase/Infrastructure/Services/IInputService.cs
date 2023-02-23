using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public interface IInputService : IService
    {
        Vector3 AttackPosition { get; }
        bool IsTapped { get; }
    }
}
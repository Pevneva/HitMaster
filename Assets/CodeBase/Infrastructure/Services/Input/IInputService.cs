using UnityEngine;

namespace CodeBase.Infrastructure.Services.Input
{
    public interface IInputService : IService
    {
        Vector3 AttackPosition { get; }
        bool IsTapped { get; }
    }
}
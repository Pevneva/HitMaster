using CodeBase.Player;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer(Vector3 at);
        PlayerMover PlayerMover { get; }
        PlayerAttack PlayerAttack { get; }
        Transform PlayerTransform { get; set; }
        void CreateEnemy(Vector3 at);
        void CreateEnemy(Vector3 at, Transform parent);
    }
}
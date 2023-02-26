using CodeBase.Player;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer(Vector3 at);
        PlayerMover PlayerMover { get; }
        PlayerAttack PlayerAttack { get; }
        void CreateEnemy(Vector3 at, Transform parent);
        GameObject CreateCamera();
        GameObject CreateHud();
    }
}
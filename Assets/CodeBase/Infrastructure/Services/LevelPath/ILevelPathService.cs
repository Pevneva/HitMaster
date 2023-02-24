using UnityEngine;

namespace CodeBase.Infrastructure.Services.LevelPath
{
    public interface ILevelPathService : IService
    {
        int CurrentPointNumber { get; set; }
        Vector3 WayPointPosition(int by);
        bool LastPointReached();
        int EnemiesCountAtPoint(int index);
    }
}
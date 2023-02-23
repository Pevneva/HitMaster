
using CodeBase.StaticData;

namespace CodeBase.Infrastructure.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        LevelPathStaticData GetAllWayPointsData();
        void LoadWayPoints();
        void LoadEnemiesPoints();
        EnemySpawnPointsStaticData GetAllEnemiesData();
    }
}
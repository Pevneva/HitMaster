
using CodeBase.StaticData;

namespace CodeBase.Infrastructure.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        LevelPathStaticData LevelPathStaticData();
        void LoadWayPoints();
        void LoadEnemyData();
        EnemyStaticData EnemyStaticData();
        void LoadPlayerData();
        PlayerStaticData PlayerStaticData();
    }
}
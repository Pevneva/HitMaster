
using CodeBase.StaticData;

namespace CodeBase.Infrastructure.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        LevelPathStaticData LevelPathStaticData();
        void LoadWayPoints();
        void LoadEnemyData();
        void LoadPlayerData();
        void LoadBulletData();
        EnemyStaticData EnemyStaticData();
        PlayerStaticData PlayerStaticData();
        BulletStaticData BulletStaticData();
    }
}
using CodeBase.Infrastructure.Services.AssetManagment;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private LevelPathStaticData _wayPoints;
        private EnemyStaticData _enemyStaticData;
        private PlayerStaticData _playerStaticData;

        public void LoadWayPoints() => 
            _wayPoints = Resources.Load<LevelPathStaticData>(path: AssetPath.WayPointsDataPath);
        
        public void LoadEnemyData() => 
            _enemyStaticData = Resources.Load<EnemyStaticData>(path: AssetPath.EnemyDataPath);
        
        public void LoadPlayerData() => 
            _playerStaticData = Resources.Load<PlayerStaticData>(path: AssetPath.PlayeDataPath);

        public LevelPathStaticData LevelPathStaticData() => 
            _wayPoints;
        
        public EnemyStaticData EnemyStaticData() => 
            _enemyStaticData; 
        
        public PlayerStaticData PlayerStaticData() => 
            _playerStaticData;
    }
}
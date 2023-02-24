using CodeBase.Infrastructure.Services.AssetManagment;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private LevelPathStaticData _wayPoints;
        private EnemyStaticData _enemyStaticData;

        public void LoadWayPoints() => 
            _wayPoints = Resources.Load<LevelPathStaticData>(path: AssetPath.WayPointsPath);
        
        public void LoadEnemyData() => 
            _enemyStaticData = Resources.Load<EnemyStaticData>(path: AssetPath.EnemyPath);

        public LevelPathStaticData LevelPathStaticData() => 
            _wayPoints;
        
        public EnemyStaticData EnemyStaticData() => 
            _enemyStaticData;
    }
}
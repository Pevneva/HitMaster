using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string SpawnersPath = "StaticData/Spawners/StaticData";
        private const string EnemyPath = "StaticData/Enemy/StaticData";
        
        private LevelPathStaticData _wayPoints;
        private EnemySpawnPointsStaticData _enemiesPoints;
        
        public void LoadWayPoints() => 
            _wayPoints = Resources.Load<LevelPathStaticData>(path: SpawnersPath);  
        
        public void LoadEnemiesPoints() => 
            _enemiesPoints = Resources.Load<EnemySpawnPointsStaticData>(path: EnemyPath);

        public LevelPathStaticData GetAllWayPointsData() => 
            _wayPoints;

        public EnemySpawnPointsStaticData GetAllEnemiesData() => 
            _enemiesPoints;
    }
}
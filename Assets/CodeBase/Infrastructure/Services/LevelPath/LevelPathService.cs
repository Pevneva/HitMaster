using CodeBase.Infrastructure.Services.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.LevelPath
{
    public class LevelPathService : ILevelPathService
    {
        private readonly IStaticDataService _staticData;

        public LevelPathService(IStaticDataService staticData) => 
            _staticData = staticData;

        public int CurrentPointNumber { get; set; }

        public bool LastPointReached() => 
            CurrentPointNumber == _staticData.LevelPathStaticData().AllWayPoints.Count - 1;

        public Vector3 WayPointPosition(int by) =>
            _staticData.LevelPathStaticData().AllWayPoints[by].At;
        
        public int EnemiesCountAtPoint(int index) => 
            _staticData.LevelPathStaticData().AllWayPoints[index].EnemiesCount;
    }
}
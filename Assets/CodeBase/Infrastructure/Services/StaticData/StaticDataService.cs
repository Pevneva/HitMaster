using CodeBase.Infrastructure.Services.AssetManagment;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private LevelPathStaticData _wayPoints;

        public void LoadWayPoints() => 
            _wayPoints = Resources.Load<LevelPathStaticData>(path: AssetPath.WayPointsPath);

        public LevelPathStaticData LevelPathStaticData() => 
            _wayPoints;
    }
}
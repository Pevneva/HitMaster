using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "StaticData", menuName = "Level Path/Create", order = 0)]
    public class LevelPathStaticData : ScriptableObject
    {
        public List<PointSpawnData> AllWayPoints;
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "LevelPath", menuName = "Level Path", order = 0)]
    public class LevelPathStaticData : ScriptableObject
    {
        public List<PointSpawnData> AllWayPoints;
    }
}
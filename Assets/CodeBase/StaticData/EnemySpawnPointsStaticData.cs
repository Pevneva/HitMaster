using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "StaticData", menuName = "AllEnemies/New", order = 0)]
    public class EnemySpawnPointsStaticData : ScriptableObject
    {
        public List<EnemySpawnData> EnemySpawnPoints;
    }
}
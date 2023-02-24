using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData
{
    [Serializable]
    public class PointSpawnData
    {
        [HideInInspector] public int EnemiesCount;
        
        public Vector3 At;
        public List<EnemySpawnData> EnemyDatas;

        public PointSpawnData(Vector3 at, int enemiesCount, List<EnemySpawnData> enemyDatas)
        {
            At = at;
            EnemyDatas = enemyDatas;
            EnemiesCount = enemiesCount;
        }
    }
}
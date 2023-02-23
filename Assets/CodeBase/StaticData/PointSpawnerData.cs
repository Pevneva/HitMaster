using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData
{
    [Serializable]
    public class PointSpawnerData
    {
        public int Id;
        public Vector3 At;
        public List<EnemySpawnData> EnemyDatas;

        public PointSpawnerData(int id, Vector3 at, List<EnemySpawnData> enemyDatas)
        {
            Id = id;
            At = at;
            EnemyDatas = enemyDatas;
        }
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData
{
    [Serializable]
    public class PointSpawnData
    {
        [HideInInspector] [SerializeField] private int _enemiesCount;
        [SerializeField] private Vector3 _at;

        public List<EnemySpawnData> EnemyDatas;
        public Vector3 At => _at;
        public int EnemiesCount => _enemiesCount;

        public PointSpawnData(Vector3 at, int enemiesCount, List<EnemySpawnData> enemyDatas)
        {
            _at = at;
            EnemyDatas = enemyDatas;
            _enemiesCount = enemiesCount;
        }
    }
}
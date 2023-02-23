using System;
using UnityEngine;

namespace CodeBase.StaticData
{
    [Serializable]
    public class EnemySpawnData
    {
        public EnemySpawnData(Vector3 position) => 
            Position = position;

        public Vector3 Position;
    }
}
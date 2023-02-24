using System;
using UnityEngine;

namespace CodeBase.StaticData
{
    [Serializable]
    public class EnemySpawnData
    {
        public Vector3 Position;

        public EnemySpawnData(Vector3 position) => 
            Position = position;
    }
}
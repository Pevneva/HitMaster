using System;
using UnityEngine;

namespace CodeBase.StaticData
{
    [Serializable]
    public class EnemySpawnData
    {
        [SerializeField] private Vector3 _position;
        
        public Vector3 Position => _position;

        public EnemySpawnData(Vector3 position) => 
            _position = position;
    }
}
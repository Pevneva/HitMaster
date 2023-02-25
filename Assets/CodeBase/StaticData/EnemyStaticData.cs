using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Enemy", order = 0)]
    public class EnemyStaticData : ScriptableObject
    {
        [Range(1, 100)] public int Hp = 10;
        
        [Range(1, 5)] public float DelayAfterDeath = 2;

        [Range(1, 10)] public float SpeedRotateToPlayer = 7;

        public GameObject Prefab;
    }
}
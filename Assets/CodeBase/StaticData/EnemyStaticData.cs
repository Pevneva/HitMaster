using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Enemy", order = 0)]
    public class EnemyStaticData : ScriptableObject
    {
        [Range(1, 100)] [SerializeField] private int _hp = 10;

        [Range(1, 5)] [SerializeField] private float _delayAfterDeath = 2;

        [Range(1, 10)] [SerializeField] private float _speedRotateToPlayer = 7;

        [SerializeField] private GameObject _prefab;

        public int Hp => _hp;
        public float DelayAfterDeath => _delayAfterDeath;
        public float SpeedRotateToPlayer => _speedRotateToPlayer;
        public GameObject Prefab => _prefab;
    }
}
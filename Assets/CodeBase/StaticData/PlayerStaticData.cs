using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "Player", menuName = "Player", order = 0)]
    public class PlayerStaticData : ScriptableObject
    {
        [Range(0, 5)] [SerializeField] private float _delayBeforeMoving = 0.45f;

        [Range(0, 3)] [SerializeField] private float _attackCooldown = 0.5f;

        [Range(0, 5)] [SerializeField] private float _delayBeforeRestartLevel = 3;

        [Range(0.5f, 15)] [SerializeField] private float _speed = 5f;

        [SerializeField] private GameObject _prefab;
        
        public float DelayBeforeMoving => _delayBeforeMoving;
        public float AttackCooldown => _attackCooldown;
        public float DelayBeforeRestartLevel => _delayBeforeRestartLevel;
        public float Speed => _speed;
        public GameObject Prefab => _prefab;
    }
}
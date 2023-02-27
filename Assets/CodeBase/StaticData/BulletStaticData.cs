using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "Bullet", menuName = "Bullet", order = 0)]
    public class BulletStaticData : ScriptableObject
    {
        [Range(1, 50)] [SerializeField] private int _damage = 10;
        
        [Range(1, 15)] [SerializeField] private float _speed = 8f;
        
        [SerializeField] private GameObject _prefab;
        
        public int Damage => _damage;
        public float Speed => _speed;
        public GameObject Prefab => _prefab;
    }
}
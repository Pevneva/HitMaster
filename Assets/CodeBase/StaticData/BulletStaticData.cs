using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "Bullet", menuName = "Bullet", order = 0)]
    public class BulletStaticData : ScriptableObject
    {
        [Range(1, 50)] public int Damage = 10;

        [Range(1, 15)] public float Speed = 8f;

        public GameObject Prefab;
    }
}
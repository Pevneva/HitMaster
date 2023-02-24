using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Bullet
{
    public class BulletAttack : MonoBehaviour
    {
        private Transform _playerTransform;
        
        public float Damage { get; set; }
        
        public void Construct(Transform player) => 
            _playerTransform = player;
        
        private void OnTriggerEnter(Collider hittable)
        {
            hittable.transform.parent.GetComponent<IHealth>().TakeDamage(Damage);
            gameObject.SetActive(false);
            transform.parent = _playerTransform;
        }
    }
}
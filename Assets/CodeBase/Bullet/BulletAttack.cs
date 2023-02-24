﻿using CodeBase.Enemy;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Bullet
{
    public class BulletAttack : MonoBehaviour
    {
        [SerializeField] private float _damage = 10;
        
        private Transform _playerTransform;

        public void Construct(Transform player) => 
            _playerTransform = player;
        
        private void OnTriggerEnter(Collider hittable)
        {
            hittable.transform.parent.GetComponent<IHealth>().TakeDamage(_damage);
            gameObject.SetActive(false);
            transform.parent = _playerTransform;
        }
    }
}
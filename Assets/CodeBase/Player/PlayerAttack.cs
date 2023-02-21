using System;
using CodeBase.Data;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.AssetManagment;
using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        private const float ShootHeight = 0.75f;
        
        public static IInputService InputService = new InputService();
        public static IAssetProvider Assets = new AssetProvider();

        private Vector3 _attackDirection;
        private Vector3 _attackPosition;

        private void Update()
        {
            if (InputService.AttackPosition == Vector3.zero)
                return;

            _attackDirection = GetAttackDirection(InputService.AttackPosition);
            Rotate(_attackDirection);
            Attack(_attackDirection);
        }

        private Vector3 GetAttackDirection(Vector3 attackPosition)
        {
            _attackDirection = WorldAttackPosition(attackPosition) - transform.position;
            _attackDirection.y = 0;
            _attackDirection.Normalize();
            return _attackDirection;
        }

        private Vector3 WorldAttackPosition(Vector3 attackPosition) =>
            Camera.main.ScreenToWorldPoint(new Vector3(attackPosition.x, attackPosition.y, 10));

        private void Rotate(Vector3 attackDirection) =>
            transform.forward = attackDirection;

        private void Attack(Vector3 direction)
        {
            GameObject bulletObject = Assets.Instantiate(AssetsPath.BulletPath, transform.position.AddY(ShootHeight));
            bulletObject.GetComponent<Bullet.Bullet>().Construct(direction);
        }
    }
}
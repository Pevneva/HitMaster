using CodeBase.Bullet;
using CodeBase.Data;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.AssetManagment;
using CodeBase.Infrastructure.Services.Factory;
using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        private const float ShootHeight = 1.25f;
        
        public static IInputService InputService = new InputService();
        public static IAssetProvider Assets = new AssetProvider();
        public static IBulletFactory BulletFactory = new BulletFactory(Assets);

        private Vector3 _attackDirection;

        private void Start() => 
            BulletFactory.InitializePool(transform.GetComponentInChildren<BulletsContainer>().transform);

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
            GameObject bullet = BulletFactory.CreateArrow(transform);
            bullet.GetComponent<BulletMover>().Construct(direction);
            bullet.transform.position = bullet.transform.position.AddY(ShootHeight);
            bullet.SetActive(true);
        }
    }
}
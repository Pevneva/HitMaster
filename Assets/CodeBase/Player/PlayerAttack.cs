using System;
using System.Collections;
using CodeBase.Bullet;
using CodeBase.Data;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Factory;
using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        private const float ShootHeight = 1.25f;
        private const float AttackCooldown = 0.5f;

        private Transform _bulletContainer;
        private IInputService _inputService;
        private IBulletFactory _bulletFactory;
        private Vector3 _attackDirection;
        private bool _isAttackState;
        private float _attackCooldown;

        public event Action EnemiesDefeated;

        public void Construct(IInputService inputService, IBulletFactory bulletFactory)
        {
            _inputService = inputService;
            _bulletFactory = bulletFactory;
        }

        private void Start()
        {
            _bulletContainer = transform.GetComponentInChildren<BulletsContainer>().transform;
            _bulletFactory.InitializePool(_bulletContainer);
        }

        private void Update()
        {
            UpdateCooldown();

            if (NotCanAttack())
                return;

            _attackDirection = GetAttackDirection(_inputService.AttackPosition);

            Attack(_attackDirection);
            Rotate(_attackDirection);
        }

        private bool NotCanAttack() => 
            _isAttackState == false || CooldownIsUp() == false || NotTapped();

        public void AttackStateOn()
        {
            _isAttackState = true;
            
            StartCoroutine(AttackingTimer()); //todo
        }

        public void AttackStateOff() => _isAttackState = false;

        private bool NotTapped() => _inputService.AttackPosition == Vector3.zero;

        private void UpdateCooldown()
        {
            if (CooldownIsUp() == false)
                _attackCooldown -= Time.deltaTime;
        }

        private bool CooldownIsUp() =>
            _attackCooldown <= 0;

        private Vector3 GetAttackDirection(Vector3 attackPosition)
        {
            Vector2 screenDirection = attackPosition - Camera.main.WorldToScreenPoint(transform.position);
            
            Vector3 worldDirection = new Vector3(screenDirection.x, 0, screenDirection.y);
            worldDirection.Normalize();
            
            return worldDirection;
        }

        private void Rotate(Vector3 attackDirection) =>
            transform.forward = attackDirection;

        private void Attack(Vector3 direction)
        {
            GameObject bullet = _bulletFactory.CreateBullet(_bulletContainer);
            bullet.transform.position = bullet.transform.position.AddY(ShootHeight);
            bullet.GetComponent<BulletMover>().Construct(direction);
            bullet.SetActive(true);
            
            _attackCooldown = AttackCooldown;
        }

        private IEnumerator AttackingTimer()
        {
            yield return new WaitForSeconds(6);
            EnemiesDefeated?.Invoke();
        }
    }
}
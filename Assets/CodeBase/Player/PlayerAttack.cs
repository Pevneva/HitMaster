using System;
using System.Collections;
using CodeBase.Bullet;
using CodeBase.Data;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.Services.Input;
using CodeBase.Infrastructure.Services.LevelPath;
using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        private const float ShootHeight = 1.25f;
        
        public float AttackCooldown { get; set; }
        public float DelayBeforeMoving { get; set; }
        public float DelayBeforeRestartLevel { get; set; }

        private Transform _bulletContainer;
        private IInputService _inputService;
        private IBulletFactory _bulletFactory;
        private Vector3 _attackDirection;
        private bool _isAttackState;
        private float _attackCooldown;

        private int _diedEnemiesCount;
        private ILevelPathService _levelPathService;

        public event Action EnemiesDefeated;
        public event Action Finished;

        public void Construct(IInputService inputService, IBulletFactory bulletFactory,
            ILevelPathService levelPathService)
        {
            _inputService = inputService;
            _bulletFactory = bulletFactory;
            _levelPathService = levelPathService;
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
            _diedEnemiesCount = 0;
            
            int enemiesOnPoint = _levelPathService.EnemiesCountAtPoint(_levelPathService.CurrentPointNumber);

            CheckDiedEnemies(enemiesOnPoint);
        }

        public void IncreaseDiedEnemies()
        {
            _diedEnemiesCount++;

            int enemiesOnPoint = _levelPathService.EnemiesCountAtPoint(_levelPathService.CurrentPointNumber);

            CheckDiedEnemies(enemiesOnPoint);
        }

        private void CheckDiedEnemies(int allEnemies)
        {
            if (_diedEnemiesCount == allEnemies && _levelPathService.LastPointReached() == false)
            {
                StartCoroutine(EnemiesDefeatedDelay());
            }
            else if (_diedEnemiesCount == allEnemies && _levelPathService.LastPointReached())
            {
                _levelPathService.CurrentPointNumber = 0;
                _bulletFactory.Clear();
                Invoke(nameof(FinishCall), DelayBeforeRestartLevel);
            }
        }

        private void FinishCall() => Finished?.Invoke();

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

        private IEnumerator EnemiesDefeatedDelay()
        {
            yield return new WaitForSeconds(DelayBeforeMoving);
            EnemiesDefeated?.Invoke();
        }
    }
}
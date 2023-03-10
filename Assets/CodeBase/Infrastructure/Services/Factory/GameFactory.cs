using CodeBase.Enemy;
using CodeBase.Infrastructure.Services.AssetManagment;
using CodeBase.Infrastructure.Services.Input;
using CodeBase.Infrastructure.Services.LevelPath;
using CodeBase.Infrastructure.Services.StaticData;
using CodeBase.Logic;
using CodeBase.Player;
using CodeBase.StaticData;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;
        private readonly IStaticDataService _staticData;
        private readonly IInputService _inputService;
        private readonly IBulletFactory _bulletFactory;
        private readonly ILevelPathService _levelPathService;
        
        public PlayerMover PlayerMover { get; set; }
        public PlayerAttack PlayerAttack { get; set; }
        public Transform PlayerTransform { get; set; }
        public EnemyDeath EnemyDeath { get; set; }

        public GameFactory(IAssetProvider assets, IStaticDataService staticData, IInputService inputService, IBulletFactory bulletFactory, ILevelPathService levelPathService)
        {
            _assets = assets;
            _staticData = staticData;
            _inputService = inputService;
            _bulletFactory = bulletFactory;
            _levelPathService = levelPathService;
        }

        public void CreateEnemy(Vector3 at, Transform parent)
        {
            EnemyStaticData enemyData = _staticData.EnemyStaticData();
            
            GameObject enemy = Object.Instantiate(enemyData.Prefab, at, Quaternion.identity, parent);
            
            RotateToPlayer rotateToPlayer = enemy.GetComponent<RotateToPlayer>();
            rotateToPlayer.Construct(PlayerTransform);
            rotateToPlayer.Speed = enemyData.SpeedRotateToPlayer;
            
            IHealth health = enemy.GetComponent<IHealth>();
            health.Current = enemyData.Hp;
            health.Max = enemyData.Hp;
            
            enemy.GetComponent<ActorUI>().Construct(health);
            EnemyDeath = enemy.GetComponent<EnemyDeath>();
            EnemyDeath.DeathTime = enemyData.DelayAfterDeath;

            enemy.GetComponent<EnemyDeath>().Happened += PlayerAttack.IncreaseDiedEnemies;
        }

        public GameObject CreateCamera()
        {
            GameObject camera = _assets.Instantiate(AssetPath.CameraPrefab);
            return camera;
        }

        public GameObject CreateHud()
        {
            return _assets.Instantiate(AssetPath.HudPrefab);
        }

        public GameObject CreatePlayer(Vector3 at)
        {
            PlayerStaticData playerData = _staticData.PlayerStaticData();
            
            GameObject player = Object.Instantiate(playerData.Prefab, at, Quaternion.identity);

            PlayerTransform = player.transform;
                
            PlayerMover = player.GetComponent<PlayerMover>();
            PlayerMover.Construct(_levelPathService);
            PlayerMover.SpeedAgent = playerData.Speed;

            PlayerAttack = player.GetComponent<PlayerAttack>();
            PlayerAttack.Construct(_inputService, _bulletFactory, _levelPathService);
            PlayerAttack.AttackCooldown = playerData.AttackCooldown;
            PlayerAttack.DelayBeforeMoving = playerData.DelayBeforeMoving;
            PlayerAttack.DelayBeforeRestartLevel = playerData.DelayBeforeRestartLevel;
            
            return player;
        }
    }
}
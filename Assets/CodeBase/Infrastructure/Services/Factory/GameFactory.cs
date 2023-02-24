using CodeBase.Enemy;
using CodeBase.Infrastructure.Services.AssetManagment;
using CodeBase.Infrastructure.Services.Input;
using CodeBase.Infrastructure.Services.LevelPath;
using CodeBase.Infrastructure.Services.StaticData;
using CodeBase.Logic;
using CodeBase.Player;
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

        public void CreateEnemy(Vector3 at)
        {
            GameObject enemy = Instantiate(AssetPath.EnemyPrefab, at);
            enemy.GetComponent<RotateToPlayer>().Construct(PlayerTransform);
            
            var health = enemy.GetComponent<IHealth>();
            
            enemy.GetComponent<ActorUI>().Construct(health);
            EnemyDeath = enemy.GetComponent<EnemyDeath>();
        }

        public void CreateEnemy(Vector3 at, Transform parent)
        {
            GameObject enemy = Instantiate(AssetPath.EnemyPrefab, at, parent);
            enemy.GetComponent<RotateToPlayer>().Construct(PlayerTransform);

            enemy.GetComponent<EnemyDeath>().Happened += PlayerAttack.IncreaseDiedEnemies;
        }

        public GameObject CreatePlayer(Vector3 at)
        {
            GameObject player = Instantiate(AssetPath.PlayerPrefab, at);

            PlayerTransform = player.transform;
                
            PlayerMover = player.GetComponent<PlayerMover>();
            PlayerMover.Construct(_levelPathService);

            PlayerAttack = player.GetComponent<PlayerAttack>();
            PlayerAttack.Construct(_inputService, _bulletFactory, _levelPathService);
            
            return player;
        }

        private GameObject Instantiate(string prefabPath, Vector3 at)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath, at);
            return gameObject;
        }
        
        private GameObject Instantiate(string prefabPath, Vector3 at, Transform parent)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath, at, parent);
            return gameObject;
        }
    }
}
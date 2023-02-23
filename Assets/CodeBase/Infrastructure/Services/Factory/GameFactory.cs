using CodeBase.Enemy;
using CodeBase.Infrastructure.Services.AssetManagment;
using CodeBase.Infrastructure.Services.StaticData;
using CodeBase.Player;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;
        private readonly IStaticDataService _staticData;
        private readonly IInputService _inputService;
        private readonly IBulletFactory _bulletFactory;
        public PlayerMover PlayerMover { get; set; }
        public PlayerAttack PlayerAttack { get; set; }
        public Transform PlayerTransform { get; set; }

        public GameFactory(IAssetProvider assets, IStaticDataService staticData, IInputService inputService, IBulletFactory bulletFactory)
        {
            _assets = assets;
            _staticData = staticData;
            _inputService = inputService;
            _bulletFactory = bulletFactory;
        }

        public void CreateEnemy(Vector3 at)
        {
            GameObject enemy = Instantiate(prefabPath: AssetPath.EnemyPrefab, at: at);
            enemy.GetComponent<RotateToPlayer>().Construct(PlayerTransform);
        }

        public void CreateEnemy(Vector3 at, Transform parent)
        {
            GameObject enemy = Instantiate(prefabPath: AssetPath.EnemyPrefab, at: at, parent);
            enemy.GetComponent<RotateToPlayer>().Construct(PlayerTransform);
        }

        public GameObject CreatePlayer(Vector3 at)
        {
            GameObject player = Instantiate(prefabPath: AssetPath.PlayerPrefab, at: at);

            PlayerTransform = player.transform;
                
            PlayerMover = player.GetComponent<PlayerMover>();
            PlayerMover.Construct(staticData: _staticData);

            PlayerAttack = player.GetComponent<PlayerAttack>();
            PlayerAttack.Construct(_inputService, _bulletFactory);
            
            return player;
        }

        private GameObject Instantiate(string prefabPath, Vector3 at)
        {
            GameObject gameObject = _assets.Instantiate(path: prefabPath, at: at);
            return gameObject;
        }
        
        private GameObject Instantiate(string prefabPath, Vector3 at, Transform parent)
        {
            GameObject gameObject = _assets.Instantiate(path: prefabPath, at: at, parent);
            return gameObject;
        }
    }
}
using CodeBase.CameraLogic;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.Services.StaticData;
using CodeBase.Logic;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadSceneState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;
        private readonly IStaticDataService _staticData;

        public LoadSceneState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain,
            IGameFactory gameFactory, IStaticDataService staticData)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
            _staticData = staticData;
        }

        public void Enter(string name)
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(name: name, onLoaded: OnLoaded);
        }

        public void Exit() =>
            _loadingCurtain.Hide();

        private void OnLoaded()
        {
            InitGameWorld();
            _stateMachine.Enter<BeforeStartState>();
        }

        private void InitGameWorld()
        {

            var hero = InitPlayer();
            InitEnemies();

            CameraFollow(following: hero);
        }

        private void InitEnemies()
        {
            foreach (PointSpawnerData wayPoint in _staticData.GetAllWayPointsData().AllWayPointsWithEnemies)
            {
                foreach (var enemyPoint in wayPoint.EnemyDatas)
                    _gameFactory.CreateEnemy(at: enemyPoint.Position);            
            }
            
            // foreach (var enemyPoint in _staticData.GetAllEnemiesData().AllEnemySpawnerPoints)
            //     _gameFactory.CreateEnemy(at: enemyPoint.Position);
        }

        private GameObject InitPlayer()
        {
            GameObject hero = _gameFactory.CreatePlayer(at: FirstWayPointPosition());
            return hero;
        }

        private Vector3 FirstWayPointPosition() => 
            _staticData.GetAllWayPointsData().AllWayPointsWithEnemies[index: 0].At;

        private void CameraFollow(GameObject following)
        {
            Camera.main
                .GetComponent<CameraFollow>()
                .Follow(following: following);
        }
    }
}
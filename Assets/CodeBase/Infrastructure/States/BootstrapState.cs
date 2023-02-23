using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.AssetManagment;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.Services.StaticData;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
       private const string Initial = "Initial";
       private const string Main = "Main";
        
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            RegisterServices();
        }

        public void Enter() => _sceneLoader.Load(Initial, EnterLoadLevel);

        private void EnterLoadLevel() => _stateMachine.Enter<LoadSceneState, string>(Main);

        private void RegisterServices()
        {
            RegisterStaticData();
            _services.RegisterSingle<IInputService>(new InputService());
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IBulletFactory>(new BulletFactory(_services.Single<IAssetProvider>()));
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssetProvider>(),
                _services.Single<IStaticDataService>(), _services.Single<IInputService>(),
                _services.Single<IBulletFactory>()));
        }

        private void RegisterStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.LoadWayPoints();
            staticData.LoadEnemiesPoints();
            _services.RegisterSingle(staticData);
        }

        public void Exit()
        {
        }
    }
}
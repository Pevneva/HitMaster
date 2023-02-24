using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Input;

namespace CodeBase.Infrastructure.States
{
    public class BeforeStartState : IUpdateListener
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IInputService _inputService;
        private readonly Updater _updater;

        public BeforeStartState(GameStateMachine stateMachine, IInputService inputService, Updater updater)
        {
            _stateMachine = stateMachine;
            _inputService = inputService;
            _updater = updater;
        }

        public void Enter() => 
            _updater.Init(listener: this);

        public void Update(float deltaTime)
        {
            if (_inputService.IsTapped) 
                _stateMachine.Enter<PlayerMoveState>();
        }

        public void Exit() => _updater.Clear();
    }
}
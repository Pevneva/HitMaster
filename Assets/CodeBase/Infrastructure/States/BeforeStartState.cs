using CodeBase.Infrastructure.Services.Input;
using TMPro;

namespace CodeBase.Infrastructure.States
{
    public class BeforeStartState : IUpdateListener, IPayloadedState<TextMeshProUGUI>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IInputService _inputService;
        private readonly Updater _updater;
        private TextMeshProUGUI _tapText;

        public BeforeStartState(GameStateMachine stateMachine, IInputService inputService, Updater updater)
        {
            _stateMachine = stateMachine;
            _inputService = inputService;
            _updater = updater;
        }

        public void Update(float deltaTime)
        {
            if (_inputService.IsTapped)
                _stateMachine.Enter<PlayerMoveState, TextMeshProUGUI>(_tapText);
        }

        public void Enter(TextMeshProUGUI tapText)
        {
            _updater.Init(listener: this);
            _tapText = tapText;
        }

        public void Exit() => _updater.Clear();
    }
}
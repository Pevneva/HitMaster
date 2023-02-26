using CodeBase.Infrastructure.Services.Factory;
using TMPro;

namespace CodeBase.Infrastructure.States
{
    public class PlayerMoveState : IPayloadedState<TextMeshProUGUI>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IGameFactory _factory;

        public PlayerMoveState(GameStateMachine stateMachine, IGameFactory factory)
        {
            _stateMachine = stateMachine;
            _factory = factory;
        }

        private void EnterAttackState()
        {
            _stateMachine.Enter<PlayerAttackState>();
            _factory.PlayerMover.WayPointReached -= EnterAttackState;
        }

        public void Enter(TextMeshProUGUI tapText)
        {
            if (tapText != null)
                tapText.enabled = false;
            
            _factory.PlayerMover.WayPointReached += EnterAttackState;
            _factory.PlayerMover.MoveStateOn();
        }

        public void Exit() => _factory.PlayerMover.MoveStateOff();
    }
}
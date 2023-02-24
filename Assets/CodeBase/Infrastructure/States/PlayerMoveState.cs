using CodeBase.Infrastructure.Services.Factory;

namespace CodeBase.Infrastructure.States
{
    public class PlayerMoveState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IGameFactory _factory;

        public PlayerMoveState(GameStateMachine stateMachine, IGameFactory factory)
        {
            _stateMachine = stateMachine;
            _factory = factory;
        }

        public void Enter()
        {
            _factory.PlayerMover.WayPointReached += EnterAttackState;
            _factory.PlayerMover.MoveStateOn();
        }
        
        private void EnterAttackState()
        {
            _stateMachine.Enter<PlayerAttackState>();
            _factory.PlayerMover.WayPointReached -= EnterAttackState;
        }

        public void Exit() => _factory.PlayerMover.MoveStateOff();
    }
}
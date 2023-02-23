using CodeBase.Infrastructure.Services.Factory;

namespace CodeBase.Infrastructure.States
{
    public class PlayerAttackState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IGameFactory _factory;

        public PlayerAttackState(GameStateMachine stateMachine, IGameFactory factory)
        {
            _stateMachine = stateMachine;
            _factory = factory;
        }

        public void Enter()
        {
            _factory.PlayerAttack.AttackStateOn();
            _factory.PlayerAttack.EnemiesDefeated += EnterMovingState;
        }

        private void EnterMovingState()
        {
            _factory.PlayerAttack.EnemiesDefeated -= EnterMovingState;
            _stateMachine.Enter<PlayerMoveState>();
        }

        public void Exit() => _factory.PlayerAttack.AttackStateOff();
    }
}
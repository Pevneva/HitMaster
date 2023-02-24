using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        private static readonly int MoveHash = Animator.StringToHash("Run");

        [SerializeField] private Animator _animator;
        [SerializeField] public PlayerMover _playerMover;
        
        private void Update() =>
            _animator.SetBool(MoveHash, _playerMover.Speed > 0);
    }
}
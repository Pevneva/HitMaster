using UnityEngine;

namespace CodeBase.Infrastructure.Services.Input
{
    public class InputService : IInputService
    {
        public Vector3 AttackPosition => ClickedPosition();
        public bool IsTapped => Tapped();

        private static Vector3 ClickedPosition()
        {
            if (Tapped())
                return UnityEngine.Input.mousePosition;

            return Vector3.zero;
        }

        private static bool Tapped() => 
            UnityEngine.Input.GetMouseButtonUp(button: 0);
    }
}
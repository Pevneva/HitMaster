using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public class InputService : IInputService
    {
        public Vector3 AttackPosition => ClickedPosition();
        public bool IsTapped => Tapped();

        private static Vector3 ClickedPosition()
        {
            if (Tapped())
                return Input.mousePosition;

            return Vector3.zero;
        }

        private static bool Tapped() => 
            Input.GetMouseButtonUp(button: 0);
    }
}
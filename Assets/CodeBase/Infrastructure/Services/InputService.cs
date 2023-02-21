using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public class InputService : IInputService
    {
        public Vector3 AttackPosition => ClickedPosition();

        private static Vector3 ClickedPosition()
        {
            if (Input.GetMouseButtonUp(0))
                return Input.mousePosition;

            return Vector3.zero;
        }
    }
}
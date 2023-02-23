using UnityEngine;

namespace CodeBase.Data
{
    public static class DataExtension
    {
        public static Vector3 AddY(this Vector3 vector, float value) =>
            new Vector3(x: vector.x, y: vector.y + value, z: vector.z);
    }
}
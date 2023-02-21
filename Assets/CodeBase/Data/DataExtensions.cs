using UnityEngine;

namespace CodeBase.Data
{
    public static class DataExtension
    {
        public static Vector3 AddY(this Vector3 vector, float value) =>
            new Vector3(vector.x, vector.y + value, vector.z);
    }
}
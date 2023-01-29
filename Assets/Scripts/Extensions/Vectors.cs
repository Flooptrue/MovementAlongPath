using UnityEngine;

namespace Extensions
{
    public static class Vectors
    {
        public static Vector3 RemoveY(this Vector3 value) => new(value.x, 0, value.z);
    }
}
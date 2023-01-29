namespace Extensions
{
    public static class Vector3
    {
        public static UnityEngine.Vector3 RemoveY(this UnityEngine.Vector3 value) => new(value.x, 0, value.z);
    }
}
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "Movement", menuName = "Road/Configs/Movement", order = 0)]
    public class Movement : ScriptableObject
    {
        [field: SerializeField]
        public float MoveSpeed { get; private set; }

        [field: SerializeField]
        public float RotationSpeed { get; private set; }

        [field: SerializeField]
        public float MaxSlopeAngle { get; private set; }
    }
}
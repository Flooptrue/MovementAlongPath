using Constants;
using UnityEngine;

namespace Movement
{
    public class Avatar
    {
        private readonly Input.Movement _input;
        private readonly float          _maxSlopeAngle;

        public Avatar(Input.Movement input, float maxSlopeAngle)
        {
            _input         = input;
            _maxSlopeAngle = maxSlopeAngle;
        }

        public bool CanMove(float slopeAngle)
        {
            return _input.IsMoving && CanWalkOnSlope(slopeAngle);
        }

        private bool CanWalkOnSlope(float slopeAngle)
        {
            return Mathf.Abs(_maxSlopeAngle - slopeAngle) < Comparison.TOLERANCE;
        }
    }
}
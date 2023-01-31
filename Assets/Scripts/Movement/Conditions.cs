using Constants;
using UnityEngine;

namespace Movement
{
    public class Conditions
    {
        private readonly Input.Movement _input;
        private readonly float          _maxSlopeAngle;

        public Conditions(Input.Movement input, float maxSlopeAngle)
        {
            _input         = input;
            _maxSlopeAngle = maxSlopeAngle;
        }

        public bool CanMove(float slopeAngle)
        {
            return _input && CanWalkOnSlope(slopeAngle);
        }

        private bool CanWalkOnSlope(float slopeAngle)
        {
            return Mathf.Abs(_maxSlopeAngle - slopeAngle) < Comparison.TOLERANCE;
        }
    }
}
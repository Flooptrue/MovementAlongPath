using Constants;
using UnityEngine;

namespace Movement.Conditions
{
    public class Avatar : ICondition
    {
        private readonly Input.Movement _input;
        private readonly float          _maxSlopeAngle;

        public Avatar(Input.Movement input, float maxSlopeAngle)
        {
            _input         = input;
            _maxSlopeAngle = maxSlopeAngle;
        }

        public bool CanMove(State state)
        {
            return _input.IsMoving && CanWalkOnSlope(slopeAngle);
        }

        private bool CanWalkOnSlope(float slopeAngle)
        {
            return Mathf.Abs(_maxSlopeAngle - slopeAngle) < Comparison.TOLERANCE;
        }
    }
}
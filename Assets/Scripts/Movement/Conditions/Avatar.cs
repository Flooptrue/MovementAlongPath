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
            var isMoving       = _input.IsMoving;
            var canWalkOnSlope = CanWalkOnSlope(state);

            return isMoving && canWalkOnSlope;
        }

        private bool CanWalkOnSlope(State state)
        {
            var slopeAngle     = CalculateSlopeAngle(state);
            var canWalkOnSlope = _maxSlopeAngle - slopeAngle > Comparison.TOLERANCE;

            return canWalkOnSlope;
        }

        private static float CalculateSlopeAngle(State state)
        {
            var forward         = state.ForwardDirection;
            var targetDirection = state.Target - state.Position;
            var slopeAngle      = Vector3.Angle(forward, targetDirection);

            return slopeAngle;
        }
    }
}
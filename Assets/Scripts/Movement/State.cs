using UnityEngine;

namespace Movement
{
    public readonly struct State
    {
        public Vector3 Position { get; }
        public Vector3 ForwardDirection { get; }
        public Vector3 Target { get; }

        public State(Vector3 position, Vector3 forwardDirection, Vector3 target)
        {
            Position         = position;
            ForwardDirection = forwardDirection;
            Target           = target;
        }
    }
}
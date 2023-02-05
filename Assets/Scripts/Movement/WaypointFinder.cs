using Constants;
using UnityEngine;

namespace Movement
{
    public class WaypointFinder
    {
        public WaypointFinder(Road road, Transform wanderer)
        {
            Road     = road;
            Wanderer = wanderer;
            Target   = Road.GetNext(null);
        }

        private Road      Road     { get; }
        private Transform Wanderer { get; }
        private Waypoint  Target   { get; set; }

        public Vector3 TargetPosition => Target.Position;

        public void Update()
        {
            var arePositionsEqual = Vector3.Distance(Wanderer.position, TargetPosition) < Comparison.TOLERANCE;

            if (arePositionsEqual && Road.IsLast(Target) == false)
            {
                Target = Road.GetNext(Target);
            }
        }
    }
}
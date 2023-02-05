using Extensions;
using Movement.Conditions;
using UnityEngine;

namespace Movement
{
    public class WaypointMover : MonoBehaviour
    {
        #region SerializeFields

        [SerializeField] private Road _road;

        #endregion

        #region Construction

        public void Init(Configs.Movement config, ICondition condition)
        {
            Config         = config;
            Condition      = condition;
            WaypointFinder = new WaypointFinder(_road, transform);

            MoveToStart();
        }

        #endregion

        #region Public API

        public bool IsMoving { get; set; }

        public void MoveToStart()
        {
            transform.position = WaypointFinder.TargetPosition;
            WaypointFinder.Update();
            transform.LookAt(WaypointFinder.TargetPosition);
        }

        #endregion

        #region Logics

        private Configs.Movement Config { get; set; }

        private ICondition Condition { get; set; }

        private WaypointFinder WaypointFinder { get; set; }

        private void Update()
        {
            if (CanMove() == false)
            {
                return;
            }

            transform.position = CalculatePosition();
            transform.rotation = CalculateRotation();

            WaypointFinder.Update();
        }

        private bool CanMove()
        {
            var thisTransform   = transform;
            var position        = thisTransform.position;
            var forwardRotation = thisTransform.forward;
            var target          = WaypointFinder.TargetPosition;

            var state   = new State(position, forwardRotation, target);
            var canMove = Condition.CanMove(state);

            return canMove;
        }

        private Quaternion CalculateRotation()
        {
            var currentTransform = transform;
            var from             = currentTransform.rotation;

            if (IsRotationPossible())
            {
                return from;
            }

            var direction   = WaypointFinder.TargetPosition - currentTransform.position;
            var to          = Quaternion.LookRotation(direction, currentTransform.up);
            var maxDelta    = Time.deltaTime * Config.RotationSpeed;
            var newRotation = Quaternion.RotateTowards(from, to, maxDelta);

            return newRotation;
        }

        private bool IsRotationPossible()
        {
            var direction  = WaypointFinder.TargetPosition - transform.position;
            var isPossible = direction == Vector3.zero;

            return isPossible;
        }

        private Vector3 Direction => WaypointFinder.TargetPosition - transform.position;

        private Vector3 DirectionXZ => Direction.RemoveY();

        private Vector3 CalculatePosition()
        {
            var current     = transform.position;
            var target      = WaypointFinder.TargetPosition;
            var delta       = Config.MoveSpeed * Time.deltaTime;
            var newPosition = Vector3.MoveTowards(current, target, delta);

            return newPosition;
        }

        #endregion
    }
}
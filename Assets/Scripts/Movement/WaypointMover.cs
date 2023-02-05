using Constants;
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

        #region Refs

        private Waypoint _target;

        #endregion

        #region Construction

        public void Init(Input.Movement input, Configs.Movement config, ICondition conditions)
        {
            Input      = input;
            Config     = config;
            Conditions = conditions;
        }

        private void Start()
        {
            MoveToStart();
        }

        #endregion

        #region Public API

        public bool IsMoving { get; set; }

        public void MoveToStart()
        {
            _target            = _road.GetNext(null);
            transform.position = _target.Position;

            _target = _road.GetNext(_target);
            transform.LookAt(_target.transform);
        }

        #endregion

        #region Logics

        private Input.Movement Input { get; set; }

        private Configs.Movement Config { get; set; }

        private ICondition Conditions { get; set; }

        private void Update()
        {
            IsMoving = UnityEngine.Input.GetMouseButton(0);

            if (IsMoving == false)
            {
                return;
            }

            transform.position = CalculatePosition();
            transform.rotation = CalculateRotation();

            if (Vector3.Distance(transform.position, _target.Position) < Comparison.TOLERANCE &&
                _road.IsLast(_target) == false)
            {
                _target = _road.GetNext(_target);
            }
        }

        private Quaternion CalculateRotation()
        {
            var currentTransform = transform;
            var from             = currentTransform.rotation;

            if (IsRotationPossible())
            {
                return from;
            }

            var direction   = _target.transform.position - currentTransform.position;
            var to          = Quaternion.LookRotation(direction, currentTransform.up);
            var maxDelta    = Time.deltaTime * Config.RotationSpeed;
            var newRotation = Quaternion.RotateTowards(from, to, maxDelta);

            return newRotation;
        }

        private bool IsRotationPossible()
        {
            var direction  = _target.transform.position - transform.position;
            var isPossible = direction == Vector3.zero;

            return isPossible;
        }

        private Vector3 Direction => _target.transform.position - transform.position;

        private Vector3 DirectionXZ => Direction.RemoveY();

        private Vector3 CalculatePosition()
        {
            var current     = transform.position;
            var target      = _target.Position;
            var delta       = Config.MoveSpeed * Time.deltaTime;
            var newPosition = Vector3.MoveTowards(current, target, delta);

            return newPosition;
        }

        #endregion
    }
}
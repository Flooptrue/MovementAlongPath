using Movement;
using UnityEngine;

namespace Tests
{
    [RequireComponent(typeof(Input.Movement))]
    public class Avatar : MonoBehaviour
    {
        [SerializeField] private float     _maxSlopeAngle;
        [SerializeField] private Transform _target;

        private Input.Movement             _input;
        private Movement.Conditions.Avatar _condition;

        private Vector3 _position;
        private Vector3 _forwardDirection;
        private Vector3 _targetPosition;
        private bool    _canMove;

        private void Awake()
        {
            _input     = GetComponent<Input.Movement>();
            _condition = new Movement.Conditions.Avatar(_input, _maxSlopeAngle);
        }

        private void Update()
        {
            var thisTransform = transform;
            _position         = thisTransform.position;
            _forwardDirection = thisTransform.forward;
            _targetPosition   = _target.position;

            var state = new State(_position, _forwardDirection, _targetPosition);
            _canMove = _condition.CanMove(state);
        }

        private void OnDrawGizmos()
        {
            var oldColor = Gizmos.color;

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(_position, _position + _forwardDirection * 5);

            Gizmos.color = Color.red;
            Gizmos.DrawLine(_position, _targetPosition);

            Gizmos.color = oldColor;
        }

        private void OnGUI()
        {
            var style = new GUIStyle { fontSize = 50 };
            GUILayout.Label($"Can move? - {_canMove}", style);
        }
    }
}
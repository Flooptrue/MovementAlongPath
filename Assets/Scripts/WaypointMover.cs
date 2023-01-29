using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    #region SerializeFields

    [SerializeField] private Road  _road;
    [SerializeField] private float _threshold;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    #endregion

    #region Refs

    private Waypoint _target;

    #endregion

    #region Construction

    private void Start()
    {
        IsManualControl = true;
        MoveToStart();
    }

    #endregion

    #region Public API

    public bool IsManualControl { get; set; }

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

    private void Update()
    {
        IsMoving = IsManualControl == false || Input.GetMouseButton(0);

        if (IsMoving == false)
        {
            return;
        }

        transform.position = CalculatePosition();
        transform.rotation = CalculateRotation();

        if (Vector3.Distance(transform.position, _target.Position) < _threshold && _road.IsLast(_target) == false)
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
        var maxDelta    = Time.deltaTime * _rotationSpeed;
        var newRotation = Quaternion.RotateTowards(from, to, maxDelta);

        return newRotation;
    }

    private bool IsRotationPossible()
    {
        var direction  = _target.transform.position - transform.position;
        var isPossible = direction == Vector3.zero;

        return isPossible;
    }

    private Vector3 CalculatePosition()
    {
        var current     = transform.position;
        var target      = _target.Position;
        var delta       = _moveSpeed * Time.deltaTime;
        var newPosition = Vector3.MoveTowards(current, target, delta);

        return newPosition;
    }

    #endregion
}
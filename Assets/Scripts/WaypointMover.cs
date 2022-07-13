using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    #region SerializeFields

    [SerializeField] private Road  _road;
    [SerializeField] private float _threshold;
    [SerializeField] private float _speed;

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
        if (Input.GetMouseButton(0) == false && IsManualControl)
        {
            return;
        }

        var current = transform.position;
        var target  = _target.Position;
        var delta   = _speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(current, target, delta);

        if (Vector3.Distance(current, target) < _threshold && _road.IsLast(_target) == false)
        {
            _target = _road.GetNext(_target);
            transform.LookAt(_target.transform);
        }
    }

    #endregion
}
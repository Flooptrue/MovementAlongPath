using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    [SerializeField] private Waypoints _waypoints;
    [SerializeField] private float _threshold;
    [SerializeField] private float _speed;

    private Transform _target;

    public bool IsManualControl { get; set; }

    private void Start()
    {
        IsManualControl = true;
        MoveToStart();
    }

    public void MoveToStart()
    {
        _target            = _waypoints.GetNext(null);
        transform.position = _target.position;

        _target = _waypoints.GetNext(_target);
        transform.LookAt(_target);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) == false && IsManualControl)
        {
            return;
        }
        
        var current = transform.position;
        var target = _target.position;
        var delta = _speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(current, target, delta);

        if (Vector3.Distance(current, target) < _threshold && _waypoints.IsLast(_target) == false)
        {
            _target = _waypoints.GetNext(_target);
            transform.LookAt(_target);
        }
    }
}
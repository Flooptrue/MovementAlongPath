using UnityEngine;

public class BitOfRoad : MonoBehaviour
{
    #region SerializeFields

    [SerializeField] private Direction _direction;


    [Header("Gizmos"), SerializeField] private Color _color;
    [SerializeField]                   private float _arrowheadAngle;
    [SerializeField]                   private float _arrowheadDistance;
    [SerializeField]                   private float _arrowheadLength;

    #endregion

    #region Refs

    private Waypoint[] _points;

    #endregion

    #region Construction

    private void Awake()
    {
        _points = new Waypoint[Size];
        for (var i = 0; i < Size; i++)
        {
            var pointTransform = transform.GetChild(i);
            var point          = pointTransform.GetComponent<Waypoint>();
            _points[i] = point;
        }
    }

    #endregion

    #region Public API

    public Waypoint GetPoint(int index)
    {
        return IsSameDirection()
            ? _points[index]
            : _points[Size - 1 - index];
    }

    public Waypoint GetNextPoint(Waypoint waypoint)
    {
        for (var i = 0; i < Size; i++)
        {
            if (GetPoint(i) != waypoint)
            {
                continue;
            }

            return GetPoint(i + 1);
        }

        return waypoint;
    }

    public bool IsLastPoint(Waypoint waypoint)
    {
        return IsSameDirection()
            ? waypoint == _points[Size - 1]
            : waypoint == _points[0];
    }

    #endregion

    #region Logics

    private int Size => transform.childCount;

    private bool IsSameDirection() => _direction == Direction.Same;

    private void OnDrawGizmos()
    {
        Gizmos.color = _color;

        for (var i = 0; i < Size - 1; i++)
        {
            var current  = transform.GetChild(i);
            var next     = transform.GetChild(i + 1);
            var distance = IsSameDirection() ? 1 - _arrowheadDistance : _arrowheadDistance;
            var length   = IsSameDirection() ? _arrowheadLength : -_arrowheadLength;

            ArrowGizmos.Draw2D(current.position, next.position, _arrowheadAngle, distance, length);
        }
    }

    #endregion

    #region Direction

    private enum Direction
    {
        Same,
        Reverse
    }

    #endregion
}
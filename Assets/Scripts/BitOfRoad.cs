using UnityEngine;

public class BitOfRoad : MonoBehaviour
{
    #region SerializeFields

    [SerializeField] private Direction _direction;

    #endregion

    #region Refs

    private Waypoint[] _points;

    #endregion

    #region Construction

    private void Awake()
    {
        _points = new Waypoint[Size];
        for (var i = 0; i < transform.childCount; i++)
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

    #endregion

    #region Direction

    private enum Direction
    {
        Same,
        Reverse
    }

    #endregion
}
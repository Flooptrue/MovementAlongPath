using UnityEngine;

public class Waypoints : MonoBehaviour
{
    #region Refs

    private BitOfRoad[] _bitsOfRoads;

    #endregion

    #region Construction

    private void Awake()
    {
        _bitsOfRoads = new BitOfRoad[Size];
        for (var i = 0; i < transform.childCount; i++)
        {
            var bitOfRoadTransform = transform.GetChild(i);
            var bitOfRoad          = bitOfRoadTransform.GetComponent<BitOfRoad>();
            _bitsOfRoads[i] = bitOfRoad;
        }
    }

    #endregion

    #region Public API

    public Waypoint GetNext(Waypoint currentWaypoint)
    {
        if (currentWaypoint == null)
        {
            return _bitsOfRoads[0].GetPoint(0);
        }

        var currentBitOfRoad = currentWaypoint.BitOfRoad;

        if (currentBitOfRoad.IsLastPoint(currentWaypoint) == false)
        {
            return currentBitOfRoad.GetNextPoint(currentWaypoint);
        }

        if (IsLastBitOfRoad(currentBitOfRoad) == false)
        {
            var nextBitOfRoad = GetNextBitOfRoad(currentBitOfRoad);

            return nextBitOfRoad.GetPoint(1);
        }

        return currentWaypoint;
    }

    public bool IsLast(Waypoint waypoint)
    {
        var bitOfRoad = waypoint.BitOfRoad;

        return IsLastBitOfRoad(bitOfRoad) && bitOfRoad.IsLastPoint(waypoint);
    }

    #endregion

    #region Logics

    private BitOfRoad GetNextBitOfRoad(BitOfRoad bitOfRoad)
    {
        for (var i = 0; i < _bitsOfRoads.Length; i++)
        {
            if (bitOfRoad != _bitsOfRoads[i])
            {
                continue;
            }

            return _bitsOfRoads[i + 1];
        }

        return bitOfRoad;
    }

    private bool IsLastBitOfRoad(Object bitOfRoad) => bitOfRoad == _bitsOfRoads[Size - 1];

    private int Size => transform.childCount;

    #endregion
}
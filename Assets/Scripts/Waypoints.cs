using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public Transform GetNext(Transform current)
    {
        if (current == null)
        {
            return transform.GetChild(0).GetChild(0);
        }

        var bitOfRoad = current.parent;
        var siblingIndex = current.GetSiblingIndex();

        if (siblingIndex < bitOfRoad.childCount - 1)
        {
            var nextIndex = siblingIndex + 1;
            return bitOfRoad.GetChild(nextIndex);
        }

        var bitOfRoadIndex = bitOfRoad.GetSiblingIndex();
        if (bitOfRoadIndex < transform.childCount - 1)
        {
            var nextIndex = bitOfRoadIndex + 1;
            return transform.GetChild(nextIndex).GetChild(1);
        }

        return current;
    }

    public bool IsLast(Transform waypoint)
    {
        var bitOfRoad = waypoint.parent;
        var isLastBit = bitOfRoad.GetSiblingIndex() == transform.childCount - 1;
        var isLastWaypoint = waypoint.GetSiblingIndex() == bitOfRoad.childCount - 1;

        return isLastBit && isLastWaypoint;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (var i = 0; i < transform.childCount; i++)
        {
            var bitOfRoad = transform.GetChild(i);

            for (var j = 0; j < bitOfRoad.childCount - 1; j++)
            {
                var current = bitOfRoad.GetChild(j).position;
                var next = bitOfRoad.GetChild(j + 1).position;

                Gizmos.DrawLine(current, next);
            }
        }
    }
}
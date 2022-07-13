using UnityEngine;

public static class ArrowGizmos
{
    public static void Draw3D(Vector3 a, Vector3 b, float arrowheadAngle, float arrowheadDistance,
        float arrowheadLength)
    {
        // Get the Direction of the Vector
        var dir = b - a;

        // Get the Position of the Arrowhead along the length of the line.
        var arrowPos = a + (dir * arrowheadDistance);

        // Get the Arrowhead Lines using the direction from earlier multiplied by a vector representing half of the full angle of the arrowhead (y)
        // and -1 for going backwards instead of forwards (z), which is then multiplied by the desired length of the arrowhead lines coming from the point.

        var up = Quaternion.LookRotation(dir) * new Vector3(0f, Mathf.Sin(arrowheadAngle / 72), -1f) *
                 arrowheadLength;
        var down = Quaternion.LookRotation(dir) * new Vector3(0f, -Mathf.Sin(arrowheadAngle / 72), -1f) *
                   arrowheadLength;
        var left = Quaternion.LookRotation(dir) * new Vector3(Mathf.Sin(arrowheadAngle / 72), 0f, -1f) *
                   arrowheadLength;
        var right = Quaternion.LookRotation(dir) * new Vector3(-Mathf.Sin(arrowheadAngle / 72), 0f, -1f) *
                    arrowheadLength;

        // Get the End Locations of all points for connecting arrowhead lines.
        var upPos    = arrowPos + up;
        var downPos  = arrowPos + down;
        var leftPos  = arrowPos + left;
        var rightPos = arrowPos + right;

        // Draw the line from A to B
        Gizmos.DrawLine(a, b);

        // Draw the rays representing the arrowhead.
        Gizmos.DrawRay(arrowPos, up);
        Gizmos.DrawRay(arrowPos, down);
        Gizmos.DrawRay(arrowPos, left);
        Gizmos.DrawRay(arrowPos, right);

        // Draw Connections between rays representing the arrowhead
        Gizmos.DrawLine(upPos, leftPos);
        Gizmos.DrawLine(leftPos, downPos);
        Gizmos.DrawLine(downPos, rightPos);
        Gizmos.DrawLine(rightPos, upPos);
    }

    public static void Draw2D(Vector3 a, Vector3 b, float arrowheadAngle, float arrowheadDistance,
        float arrowheadLength)
    {
        // Get the Direction of the Vector
        var dir = b - a;

        // Get the Position of the Arrowhead along the length of the line.
        var arrowPos = a + (dir * arrowheadDistance);

        // Get the Arrowhead Lines using the direction from earlier multiplied by a vector representing half of the full angle of the arrowhead (y)
        // and -1 for going backwards instead of forwards (z), which is then multiplied by the desired length of the arrowhead lines coming from the point.

        var left = Quaternion.LookRotation(dir) * new Vector3(Mathf.Sin(arrowheadAngle / 72), 0f, -1f) *
                   arrowheadLength;
        var right = Quaternion.LookRotation(dir) * new Vector3(-Mathf.Sin(arrowheadAngle / 72), 0f, -1f) *
                    arrowheadLength;

        // Draw the line from A to B
        Gizmos.DrawLine(a, b);

        // Draw the rays representing the arrowhead.
        Gizmos.DrawRay(arrowPos, left);
        Gizmos.DrawRay(arrowPos, right);
    }
}
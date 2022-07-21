using UnityEngine;

[ExecuteInEditMode]
public class Rule : MonoBehaviour
{
    [SerializeField] private float      _distance;
    [SerializeField] private GameObject _sample;

    private Waypoint[] _points;

    private void Update()
    {
        _points = GetComponentsInChildren<Waypoint>();

        if (_points.Length == 0)
        {
            Debug.LogError("You didn't add any point!");
        }
    }

    private Vector3 FindPoint()
    {
        if (_points.Length == 0)
        {
            Debug.LogError("At least one point must exist!");
            return Vector3.zero;
        }

        if (_distance < 0)
        {
            Debug.LogError("Distance cannot be less then zero!");
            return _points[0].transform.position;
        }

        var restOfDistance = _distance;

        for (var i = 0; i < _points.Length - 1; i++)
        {
            var firstPosition  = _points[i].transform.position;
            var secondPosition = _points[i + 1].transform.position;

            var vectorBetweenPoints   = secondPosition - firstPosition;
            var distanceBetweenPoints = vectorBetweenPoints.magnitude;

            if (restOfDistance <= distanceBetweenPoints)
            {
                var direction = Vector3.Normalize(vectorBetweenPoints);
                var point     = firstPosition + direction * restOfDistance;

                return point;
            }

            restOfDistance -= distanceBetweenPoints;
        }

        return _points[^1].transform.position;
    }
}
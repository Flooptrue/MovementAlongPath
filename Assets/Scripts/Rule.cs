using System.Text;
using UnityEngine;

public class Rule : MonoBehaviour
{
    [SerializeField] private float _distance;

    private Transform[] _points;

    private void Awake()
    {
        _points = new Transform[transform.childCount];
        for (var i = 0; i < _points.Length; i++)
        {
            _points[i] = transform.GetChild(i);
        }

        if (_points.Length == 0)
        {
            Debug.LogError("You didn't add any point!");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            var point = FindPoint();
            Debug.Log(point);
        }
    }

    private void PrintDistance()
    {
        var message = new StringBuilder();

        var totalDistance = 0f;
        for (var i = 0; i < _points.Length - 1; i++)
        {
            var localDistance = Vector3.Distance(_points[i].position, _points[i + 1].position);
            totalDistance += localDistance;
            message.AppendLine($"[{i}-{i + 1}] {localDistance}");
        }

        message.Insert(0, $"TotalDistance {totalDistance}\n");
        Debug.Log(message);
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
            return _points[0].position;
        }

        var restOfDistance = _distance;

        for (var i = 0; i < _points.Length - 1; i++)
        {
            var firstPosition  = _points[i].position;
            var secondPosition = _points[i + 1].position;

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

        return _points[^1].position;
    }
}
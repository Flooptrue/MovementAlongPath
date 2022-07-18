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
        if (_distance < 0)
        {
            Debug.LogError("Distance cannot be less then zero!");
            return _points[0].position;
        }

        var vectorBetweenPoints = _points[1].position - _points[0].position;
        var direction           = Vector3.Normalize(vectorBetweenPoints);
        var point               = direction * _distance;

        return point;
    }
}
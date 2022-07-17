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
            var point = FindPoint(_distance);
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

    private Vector3 FindPoint(float distance)
    {
        return Vector3.zero;
    }
}
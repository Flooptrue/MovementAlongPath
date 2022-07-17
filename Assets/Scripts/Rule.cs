using UnityEngine;

public class Rule : MonoBehaviour
{
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
            var distance = Vector3.Distance(_points[0].position, _points[1].position);
            Debug.Log($"Distance - {distance}");
        }
    }
}

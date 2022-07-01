using UnityEngine;

public class Difficulty : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        var distance = _speed * Time.fixedDeltaTime;
        var t = transform;
        t.position += t.forward * distance;
    }
}

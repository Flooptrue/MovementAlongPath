using UnityEngine;

public class Difficulty : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _lifeTime;
    private float _elapsedTime;

    public void Init(float lifeTime)
    {
        _lifeTime = lifeTime;
    }

    private void FixedUpdate()
    {
        var distance = _speed * Time.fixedDeltaTime;
        var t = transform;
        t.position += t.forward * distance;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _lifeTime)
        {
            Destroy(gameObject);
        }
    }
}

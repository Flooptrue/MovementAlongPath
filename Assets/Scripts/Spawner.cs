using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float      _interval;
    [SerializeField] private float      _lifeTime;
    [SerializeField] private Difficulty _difficulty;

    private IEnumerator Start()
    {
        while (true)
        {
            var t        = transform;
            var instance = Instantiate(_difficulty, t.position, t.rotation);
            instance.Init(_lifeTime);

            yield return new WaitForSeconds(_interval);
        }
    }
}
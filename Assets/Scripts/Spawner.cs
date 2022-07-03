using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float      _interval;
    [SerializeField] private Difficulty _difficulty;

    private IEnumerator Start()
    {
        while (true)
        {
            var t = transform;
            Instantiate(_difficulty, t.position, t.rotation);
            yield return new WaitForSeconds(_interval);
        }
    }
}
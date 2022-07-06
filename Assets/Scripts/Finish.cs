using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private float _reward;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.attachedRigidbody.GetComponent<WaypointMover>();
        player.IsManualControl = false;
    }
}
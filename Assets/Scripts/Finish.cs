using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.attachedRigidbody.GetComponent<WaypointMover>();
        player.IsManualControl = false;
    }
}

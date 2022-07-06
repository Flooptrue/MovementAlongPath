using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private int _reward;

    private void OnTriggerEnter(Collider other)
    {
        var mover = other.attachedRigidbody.GetComponent<WaypointMover>();
        mover.IsManualControl = false;
        
        var player      = other.attachedRigidbody.GetComponent<Player>();
        var totalReward = player.DeliveredItems * _reward;
    }
}
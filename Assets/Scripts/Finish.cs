using Movement;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private int _reward;

    private void OnTriggerEnter(Collider other)
    {
        var mover = other.attachedRigidbody.GetComponent<WaypointMover>();
        mover.IsManualControl = false;

        var player = other.attachedRigidbody.GetComponent<Player>();
        Money.Amount += player.DeliveredItems * _reward;
    }
}
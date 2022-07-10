using UnityEngine;

public class Player : MonoBehaviour
{
    private WaypointMover _mover;
    private byte          _items;

    private void Awake()
    {
        _mover = GetComponent<WaypointMover>();
    }

    public byte DeliveredItems { get; private set; }

    public void AddItem()
    {
        _items++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Difficulty"))
        {
            _mover.MoveToStart();
            _items         = 0;
            DeliveredItems = 0;
            return;
        }

        if (other.TryGetComponent<Recipient>(out var recipient))
        {
            var requiredNumber  = recipient.Number;
            var deliveredNumber = _items < requiredNumber ? _items : requiredNumber;

            _items         -= deliveredNumber;
            DeliveredItems += deliveredNumber;

            return;
        }
    }
}
using UnityEngine;

public class Player : MonoBehaviour
{
    private WaypointMover _mover;
    private byte          _items;
    private byte          _deliveredItems;

    private void Awake()
    {
        _mover = GetComponent<WaypointMover>();
    }

    public void AddItem()
    {
        _items++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Difficulty"))
        {
            _mover.MoveToStart();
            return;
        }

        if (other.TryGetComponent<Recipient>(out var recipient))
        {
            var requiredNumber  = recipient.Number;
            var deliveredNumber = _items < requiredNumber ? _items : requiredNumber;

            _items          -= deliveredNumber;
            _deliveredItems += deliveredNumber;

            return;
        }
    }
}
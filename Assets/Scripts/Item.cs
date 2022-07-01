using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.attachedRigidbody.GetComponent<Player>();

        if (player == null)
        {
            Debug.LogError("Can't get Player component!");
        }
        else
        {
            player.AddItem();
            Destroy(gameObject);
        }
    }
}

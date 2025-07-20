using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EXPDrop"))
        {
            collision.GetComponent<EXPPickupBehaviour>().EXPPickedUp();
        }
    }
}

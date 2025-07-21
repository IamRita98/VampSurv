using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    CircleCollider2D coll;
    CharacterStats cStats;

    private void Start()
    {
        coll = GetComponent<CircleCollider2D>();
        cStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        SetPickUpRadius();
    }

    void SetPickUpRadius()
    {
        coll.radius = cStats.pickupRadius;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EXPDrop"))
        {
            collision.GetComponent<EXPPickupBehaviour>().EXPPickedUp();
        }
    }
}

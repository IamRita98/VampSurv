using UnityEngine;

public class EXPPickupBehaviour : MonoBehaviour
{
    MoveTowardsPlayer moveTowardsPlayer;
    public int expToGive;

    public static event System.Action<int> onExpPickedUp;

    private void Start()
    {
        moveTowardsPlayer = GetComponent<MoveTowardsPlayer>();
    }

    public void EXPPickedUp()
    {
        moveTowardsPlayer.wantToMoveTowardsPlayer = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onExpPickedUp?.Invoke(expToGive);
            Destroy(this.gameObject);
        } 
    }
}

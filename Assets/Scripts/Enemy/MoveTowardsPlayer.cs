using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    GetPlayerPos getPlayerPos;
    Rigidbody2D rb;
    CharacterStats cStats;
    public Vector2 direction;
    public Vector2 currentPos;
    public Vector2 playerPos;
    public float speed;

    public bool wantToMoveTowardsPlayer = true;

    private void Start()
    {
        getPlayerPos = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GetPlayerPos>();
        rb = GetComponent<Rigidbody2D>();
        cStats = GetComponent<CharacterStats>();

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void Update()
    {
        if (!wantToMoveTowardsPlayer) return;

        if (cStats != null)
        {
            speed = cStats.speed;
        }

        GetDirection();
        direction.Normalize();
        transform.Translate(direction * (speed * Time.deltaTime));
    }

    void GetDirection()
    {
        currentPos = transform.position;
        playerPos = getPlayerPos.playerPos;
        direction = playerPos - currentPos;
    }
}

using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    GetPlayerPos getPlayerPos;
    Rigidbody2D rb;
    CharacterStats cStats;
    Vector2 direction;
    Vector2 currentPos;
    Vector2 playerPos;

    private void Start()
    {
        getPlayerPos = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GetPlayerPos>();
        rb = GetComponent<Rigidbody2D>();
        cStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        currentPos = transform.position;
        playerPos = getPlayerPos.playerPos;
        direction = playerPos - currentPos;
        direction.Normalize();
        transform.Translate(direction * (cStats.speed * Time.deltaTime));

        //transform.position = Vector2.MoveTowards(currentPos, playerPos, cStats.speed * Time.deltaTime);
    }
}

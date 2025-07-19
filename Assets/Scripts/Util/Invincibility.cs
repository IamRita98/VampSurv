using UnityEngine;

public class Invincibility : MonoBehaviour
{
    CharacterStats cStats;
    CapsuleCollider2D coll;
    Rigidbody2D rb;
    float timer;
    bool startTimer;

    private void OnEnable()
    {
        DealDamageToPlayer.onPlayerDamaged += TogglePlayerInvincibility;
    }

    private void OnDisable()
    {
        DealDamageToPlayer.onPlayerDamaged -= TogglePlayerInvincibility;
    }

    private void Update()
    {
        if (!startTimer) return;
        timer += Time.deltaTime;
        if(timer >= cStats.invincibilityTimer)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            coll.enabled = true;
            startTimer = false;
        }
    }

    void TogglePlayerInvincibility(GameObject goHit, float dmgDealt)
    {
        cStats = goHit.GetComponent<CharacterStats>();
        coll = goHit.GetComponent<CapsuleCollider2D>();
        rb = goHit.GetComponent<Rigidbody2D>();
        coll.enabled = false;
        rb.bodyType = RigidbodyType2D.Kinematic;
        timer = 0;
        startTimer = true;
    }
}

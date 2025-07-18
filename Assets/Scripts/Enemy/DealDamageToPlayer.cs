using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DealDamageToPlayer : MonoBehaviour
{
    CharacterStats cStats;
    public bool destroyEnemyOnContact;

    public static event System.Action<GameObject, float> onPlayerDamaged;

    void Start()
    {
        cStats = GetComponent<CharacterStats>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        float dmgToDeal = cStats.intensity;
        collision.gameObject.GetComponent<CharacterStats>().ChangeHP(dmgToDeal);
        collision.gameObject.GetComponentInChildren<FlashSpriteOnDamageTaken>().FlashPlayerSprite();

        onPlayerDamaged?.Invoke(collision.gameObject, dmgToDeal);
    }
}

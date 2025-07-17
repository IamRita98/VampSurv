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
        if (!collision.gameObject.CompareTag("Player")) return;

        float dmgToDeal = cStats.damage;
        collision.gameObject.GetComponent<CharacterStats>().ChangeHP(dmgToDeal);

        onPlayerDamaged?.Invoke(collision.gameObject, dmgToDeal);
    }
}

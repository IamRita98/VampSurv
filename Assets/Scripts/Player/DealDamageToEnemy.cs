using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DealDamageToEnemy : MonoBehaviour
{
    WeaponStats wStats;
    public bool destroyProjOnContact;

    public static event System.Action<GameObject> onEnemyDamaged;

    private void Start()
    {
        wStats = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) return;
        float dmgToDeal = wStats.damage;
        collision.GetComponent<CharacterStats>().hp -= dmgToDeal;
        onEnemyDamaged.Invoke(collision.gameObject);
        print(collision.gameObject);
        if (destroyProjOnContact)
        {
            Destroy(this.gameObject);
        }
    }
}

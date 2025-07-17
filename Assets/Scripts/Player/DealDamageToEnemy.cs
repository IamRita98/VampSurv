using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DealDamageToEnemy : MonoBehaviour
{
    WeaponStats wStats;
    public bool destroyProjOnContact;

    public static event System.Action<GameObject, float> onEnemyDamaged;

    private void Start()
    {
        wStats = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) return;

        float dmgToDeal = wStats.damage;
        collision.GetComponent<CharacterStats>().ChangeHP(dmgToDeal); //deal dmg

        onEnemyDamaged?.Invoke(collision.gameObject, dmgToDeal); //Send signal incase we want this anywhere else

        if (destroyProjOnContact)
        {
            Destroy(this.gameObject);
        }
    }
}

using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DealDamageToEnemy : MonoBehaviour
{
    public bool destroyProjOnContact;
    public float damageToDeal;

    public static event System.Action<GameObject, float> onEnemyDamaged;

    /// <summary>
    /// This will deal damage to the enemy once
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) return;

        collision.GetComponent<CharacterStats>().ChangeHP(damageToDeal); //deal dmg
        collision.GetComponent<FlashSpriteOnDamageTaken>().FlashEnemySprite(); //Flash sprite white

        onEnemyDamaged?.Invoke(collision.gameObject, damageToDeal); //Send signal incase we want this anywhere else

        if (destroyProjOnContact)
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// This will deal damage to the enemy every frame it stays in the collider
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
}

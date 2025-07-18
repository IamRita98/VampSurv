using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DealDamageToEnemy : MonoBehaviour
{
    public bool destroyProjOnContact;
    public float damageToDeal;

    public static event System.Action<GameObject, float> onEnemyDamaged;

    
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
}

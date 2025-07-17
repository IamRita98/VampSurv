using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DealDamageToPlayer : MonoBehaviour
{
    CharacterStats cStats;
    public bool destroyEnemyOnContact;

    public static event System.Action<GameObject> onPlayerDamaged;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

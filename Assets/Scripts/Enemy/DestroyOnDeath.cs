using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(CharacterStats))]
public class DestroyOnDeath : MonoBehaviour
{
    CharacterStats cStats;
    DropItemOnDeath dropItemOnDeath;

    private void Start()
    {
        cStats = GetComponent<CharacterStats>();
        dropItemOnDeath = GetComponent<DropItemOnDeath>();
    }

    private void Update()
    {
        if(cStats.currentHP <= 0)
        {
            dropItemOnDeath.DropItem();
            Destroy(this.gameObject);
        }
    }
}

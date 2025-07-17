using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(CharacterStats))]
public class DestroyOnDeath : MonoBehaviour
{
    CharacterStats cStats;

    private void Start()
    {
        cStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        if(cStats.hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

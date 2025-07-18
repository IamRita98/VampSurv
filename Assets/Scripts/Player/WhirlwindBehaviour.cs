using UnityEngine;

public class WhirlwindBehaviour : MonoBehaviour
{
    Timer timer;
    CharacterStats cStats;
    DealDamageToEnemy dealDamageToEnemy;

    //BaseStats
    float baseDamage = 10;
    float baseDuration = .5f;
    float baseArea = 1;

    //AdjustedStats
    float damage;
    float duration;
    float area;

    private void Start()
    {
        timer = GetComponent<Timer>();
        cStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        dealDamageToEnemy = GetComponent<DealDamageToEnemy>();

        damage = baseDamage * cStats.damage;
        duration = baseDuration * cStats.projectileDuration;
        area = baseArea * cStats.projectileArea;

        dealDamageToEnemy.damageToDeal = damage;

        timer.SetTimer(duration);

        transform.localScale *= area;
    }

    private void Update()
    {
        if (timer.timerComplete)
        {
            Destroy(this.gameObject);
        }
    }
}

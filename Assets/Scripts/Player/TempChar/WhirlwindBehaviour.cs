using UnityEngine;

public class WhirlwindBehaviour : MonoBehaviour
{
    Timer timer;
    CharacterStats cStats;
    WeaponStats wStats;
    DealDamageToEnemy dealDamageToEnemy;

    //AdjustedStats
    float damage;
    float duration;
    float area;

    private void Start()
    {
        wStats = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponStats>();
        timer = GetComponent<Timer>();
        cStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        dealDamageToEnemy = GetComponent<DealDamageToEnemy>();

        damage = wStats.damage;
        duration = wStats.projectileDuration;
        area = wStats.projectileArea;

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

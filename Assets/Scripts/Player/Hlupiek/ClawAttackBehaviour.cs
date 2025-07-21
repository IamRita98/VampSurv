using Unity.VisualScripting;
using UnityEngine;

public class ClawAttackBehaviour : MonoBehaviour
{
    Timer timer;
    WeaponStats wStats;
    GameObject player;
    DealDamageToEnemy dealDamageToEnemy;
    SpriteFlipper sFlipper;

    float duration;
    float damage;

    private void Start()
    {
        timer = GetComponent<Timer>();
        player = GameObject.FindGameObjectWithTag("Player");
        wStats = player.GetComponent<WeaponStats>();
        dealDamageToEnemy = GetComponent<DealDamageToEnemy>();
        sFlipper = player.GetComponent<SpriteFlipper>();

        damage = wStats.damage;
        dealDamageToEnemy.damageToDeal = damage;
        duration = wStats.projectileDuration;

        timer.SetTimer(duration);

        sFlipper.wantToFlip = false;
        if (sFlipper.isFlipped)
        {
            transform.parent.Rotate(0, 180, 0);
        }
    }

    private void Update()
    {
        if (!timer.timerComplete) return;
        sFlipper.wantToFlip = true;
        Destroy(transform.parent.gameObject);
    }
}

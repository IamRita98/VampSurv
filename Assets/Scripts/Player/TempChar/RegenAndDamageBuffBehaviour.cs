using UnityEngine;

/// <summary>
/// Gives char increased HP regen, gives a percent damage bonus to ability, and both a percent and flat damage bonus to sword wave
/// When it ends give a burst of healing
/// </summary>
public class RegenAndDamageBuffBehaviour : MonoBehaviour
{

    CharacterStats cStats;
    WeaponStats wStats;
    Timer timer;
    GameObject player;

    float baseRegenBuff = 1;
    float baseBurstHealing = 10;
    float baseFlatDamageBuff = 5;
    float basePercentDamageBuff = 1.2f; //20%
    float baseBuffDuration = 5;

    float regenBuff;
    float burstHealing;
    float flatDamageBuff;
    float percentDamageBuff;
    float buffDuration;

    float percentDamageBuffApplied;

    private void Start()
    {
        timer = GetComponent<Timer>();

        player = GameObject.FindGameObjectWithTag("Player");
        cStats = player.GetComponent<CharacterStats>();
        wStats = player.GetComponent<WeaponStats>();

        regenBuff = baseRegenBuff * cStats.intensity;
        burstHealing = baseBurstHealing * cStats.intensity;
        flatDamageBuff = baseFlatDamageBuff * cStats.intensity;
        percentDamageBuff = basePercentDamageBuff * cStats.intensity;
        buffDuration = baseBuffDuration * cStats.duration;

        percentDamageBuffApplied = (cStats.intensity * percentDamageBuff) - cStats.intensity;

        timer.SetTimer(buffDuration);
        ApplyRegenBuff();
        ApplyDamageBuff();

        print("Buff applied: " + cStats.intensity + " Intensity, " + cStats.hpRegen + " Regen");
    }

    private void Update()
    {
        if (timer.timerComplete)
        {
            cStats.ChangeHP(-burstHealing);
            UnapplyRegenBuff();
            UnapplyDamageBuff();

            print("Buff Ended");
            Destroy(this.gameObject);
        }
    }

    void ApplyRegenBuff()
    {
        cStats.ChangeHPRegen(regenBuff);
    }
    void UnapplyRegenBuff()
    {
        cStats.ChangeHPRegen(-regenBuff);
    }

    void ApplyDamageBuff()
    {
        cStats.ChangeIntensity(percentDamageBuff);
        wStats.ChangeDamage(flatDamageBuff);
    }
    void UnapplyDamageBuff()
    {
        cStats.ChangeIntensityFlat(-percentDamageBuffApplied);
        wStats.ChangeDamage(-flatDamageBuff);
    }
}

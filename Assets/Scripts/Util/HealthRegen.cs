using UnityEngine;

public class HealthRegen : MonoBehaviour
{
    CharacterStats cStats;
    float timer;
    float regenDuration;
    bool setTimer;
    float regenaration;
    float delayOnRegen;
    float regenFrequency;

    private void Start()
    {
        cStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
    }

    private void Update()
    {
        if (setTimer)
        {
            timer += Time.deltaTime;
        }
        if (setTimer && timer <= regenDuration)
        {
            InvokeRepeating("RegenHealth", delayOnRegen, 1 / regenFrequency);
        }
    }

    public void HPRegenCall(bool isTimed, float timerLength, float regenStartDelay, float regenRate, float regenAmount)
    {
        setTimer = isTimed;
        timer = 0;
        regenaration = regenAmount;
        regenDuration = timerLength;
        delayOnRegen = regenStartDelay;
        regenFrequency = regenRate;

        if (!isTimed)
        {
            InvokeRepeating("RegenHealth", regenStartDelay, 1 / regenRate);
        }
    }

    public void RegenHealth()
    {
        cStats.ChangeHP(-regenaration);
    }
}

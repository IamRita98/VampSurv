using System.Collections;
using UnityEngine;

public class HealthRegen : MonoBehaviour
{
    CharacterStats cStats;
    float timer;
    float regenerationDuration;

    private void Start()
    {
        cStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
    } 

    public void TimedRegen(float duration, float regenAmount)
    {
        timer = 0;
        regenerationDuration = duration;
        StartCoroutine(TimedHealthRegen(regenAmount));
    }

    public void ConstantRegen(float regenAmount)
    {
        StartCoroutine(ConstantHealthRegen(regenAmount));
    }

    IEnumerator ConstantHealthRegen(float regenAmount)
    {
        while (true)
        {
            cStats.ChangeHP(-regenAmount);
        }
    }

    IEnumerator TimedHealthRegen(float regenAmount)
    {
        if(timer >= regenerationDuration)
        {
            yield return null;
        }
        while(timer <= regenerationDuration)
        {
            cStats.ChangeHP(-regenAmount);
        }
    }
}

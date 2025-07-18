using System.Collections;
using UnityEngine;

public class HealthRegen : MonoBehaviour
{
    CharacterStats cStats;
    public float regenarationAmount;
    bool isTimed;
    float timer;
    float baseRegen;
    bool isHurt;

    public bool wantToRegen = false;

    private void Start()
    {
        cStats = GetComponent<CharacterStats>();
        baseRegen = cStats.hpRegen;
        regenarationAmount = cStats.hpRegen;
    }

    private void Update()
    {
        if (cStats.currentHP < cStats.maxHP) isHurt = true;
        else isHurt = false;

        if (isTimed)
        {
            timer -= Time.deltaTime;
        }
        if (isTimed && timer <= 0)
        {
            regenarationAmount = baseRegen;
        }

        if (!isHurt) return;

        if (isHurt)
        {
            cStats.ChangeHP(-regenarationAmount * Time.deltaTime);
        }
    }

    void IncreaseHealthRegen(float regenAmount, float regenTimer, GameObject whoToRegen)
    {
        if(regenTimer > 0)
        {
            isTimed = true;
            timer = regenTimer;
        }
        
        cStats = whoToRegen.GetComponent<CharacterStats>();
        regenarationAmount += regenAmount;
    }
}

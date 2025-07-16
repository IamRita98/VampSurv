using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public GameObject parentChar;
    public GameObject swordWave;
    Timer timer;

    public float attackSpeed;
    public float damage;
    public float projectileSpeed;
    public float projectileDuration;
    public float projectileArea;

    CharacterStats cStats;
    WeaponStats wStats;

    Dictionary<CharacterStats.CharacterName, WeaponStats> charWepStats = new();
    void Start()
    {
        cStats = parentChar.GetComponent<CharacterStats>();
        wStats = GetComponent<WeaponStats>();

        InstantiateDictionary();

        timer = GetComponent<Timer>();
        timer.SetTimer(attackSpeed);
    }

    private void Update()
    {
        if (!timer.timerComplete) return;
        timer.timerComplete = false;
        timer.SetTimer(attackSpeed);


        switch (cStats.charName)
        {
            case CharacterStats.CharacterName.TempChar:
                SwordAttack();
                break;
        }
    }

    private void SwordAttack()
    {
        GameObject instantiatedAttack = Instantiate(swordWave, transform.parent.position, Quaternion.identity);
    }

    public void InstantiateDictionary()
    {
        //AttackSpeed, Damage, projectileSpeed, projectileDuration, projectileArea
        charWepStats.Add(CharacterStats.CharacterName.TempChar, new WeaponStats(5,10,3,1,1));

        SetStats();
    }

    private void SetStats()
    {
        attackSpeed = wStats.attackSpeed;
        damage = wStats.damage;
        projectileSpeed = wStats.projectileSpeed;
        projectileDuration = wStats.projectileDuration;
        projectileArea = wStats.projectileArea;
    }
}

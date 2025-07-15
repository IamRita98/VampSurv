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


    Dictionary<CharacterStats.CharacterName, List<float>> charWepStats = new();
    void Start()
    {
        cStats = parentChar.GetComponent<CharacterStats>();

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

    private void SetStats()
    {
        attackSpeed = charWepStats[cStats.charName][0];
        damage = charWepStats[cStats.charName][1];
        projectileSpeed = charWepStats[cStats.charName][2];
        projectileDuration = charWepStats[cStats.charName][3];
        projectileArea = charWepStats[cStats.charName][4];
    }

    public void InstantiateDictionary()
    {
        //AttackSpeed, Damage, projectileSpeed, projectileDuration, projectileArea
        charWepStats.Add(CharacterStats.CharacterName.TempChar, new List<float> { 5f, 10f, 3f, 1f, 1f });

        SetStats();
    }
}

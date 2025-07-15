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

    Stats stats;


    Dictionary<Stats.CharacterName, List<float>> charWepStats = new();
    void Start()
    {
        stats = parentChar.GetComponent<Stats>();

        InstantiateDictionary();

        timer = GetComponent<Timer>();
        timer.SetTimer(attackSpeed);
    }

    private void Update()
    {
        if (!timer.timerComplete) return;
        timer.timerComplete = false;
        timer.SetTimer(attackSpeed);


        switch (stats.charName)
        {
            case Stats.CharacterName.TempChar:
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
        attackSpeed = charWepStats[stats.charName][0];
        damage = charWepStats[stats.charName][1];
        projectileSpeed = charWepStats[stats.charName][2];
        projectileDuration = charWepStats[stats.charName][3];
        projectileArea = charWepStats[stats.charName][4];
    }

    public void InstantiateDictionary()
    {
        //AttackSpeed, Damage, projectileSpeed, projectileDuration, projectileArea
        charWepStats.Add(Stats.CharacterName.TempChar, new List<float> { 5f, 10f, 3f, 1f, 1f });

        SetStats();
    }
}

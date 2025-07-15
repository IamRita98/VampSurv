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

    public string charName;
    Stats stats;

    Dictionary<string, List<float>> charWepStats = new();
    void Start()
    {
        stats = parentChar.GetComponent<Stats>();
        charName = stats.charName;

        InstantiateDictionary();

        timer = GetComponent<Timer>();
        timer.SetTimer(attackSpeed);
    }

    private void Update()
    {
        if (!timer.timerComplete) return;
        timer.timerComplete = false;
        timer.SetTimer(attackSpeed);


        switch (charName)
        {
            case "TempChar":
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
        attackSpeed = charWepStats[charName][0];
        damage = charWepStats[charName][1];
        projectileSpeed = charWepStats[charName][2];
        projectileDuration = charWepStats[charName][3];
        projectileArea = charWepStats[charName][4];
    }

    public void InstantiateDictionary()
    {
        //AttackSpeed, Damage, projectileSpeed, projectileDuration, projectileArea
        charWepStats.Add("TempChar", new List<float> { 5f, 10f, 3f, 1f, 1f });

        SetStats();
    }
}

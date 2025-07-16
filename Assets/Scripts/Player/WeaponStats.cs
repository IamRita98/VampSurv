using System.Collections.Generic;
using UnityEngine;
using static CharacterStats;

[RequireComponent(typeof(CharacterStats))]
public class WeaponStats : MonoBehaviour
{
    public float attackSpeed;
    public float damage;
    public float projectileSpeed;
    public float projectileDuration;
    public float projectileArea;

    CharacterStats cStats;

    Dictionary<CharacterName, WeaponStatConstructor> wepStats = new();

    private void Start()
    {
        cStats = GetComponent<CharacterStats>();
        InstanDict();
    }

    private void SetStats(CharacterName charName)
    {
        attackSpeed = wepStats[charName].weaponFireRate * cStats.attackSpeed; //This formula will make attacking take longer if cStats attackspeed is > 1
        damage = wepStats[charName].weaponDmg * cStats.damage;
        projectileSpeed = wepStats[charName].weaponProjSpeed * cStats.projectileSpeed;
        projectileDuration = wepStats[charName].weaponProjDur * cStats.projectileDuration;
        projectileArea = wepStats[charName].weaponProjArea * cStats.projectileArea;
    }

    private void InstanDict()
    {
        wepStats.Add(CharacterName.TempChar, new WeaponStatConstructor
            (atkSpeed: 5, dmg: 10, projSpeed: 3, projDur: 1, projArea: 1));

        SetStats(cStats.charName);
    }
}

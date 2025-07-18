using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public float currentHP;
    public float maxHP;
    public float hpRegen;
    public float speed;
    public float abilityCooldown;

    public float attackSpeed;
    public float damage;
    public float projectileSpeed;
    public float projectileDuration;
    public float projectileArea;

    public enum CharacterName 
    { 
        TempChar,
        FillerChar,

        Zombie,
        TankyZombie
    }
    public CharacterName charName;


    Dictionary<CharacterName, StatConstructor> charStats = new();

    private void Start()
    {
        InstantiateDict();
        currentHP = maxHP;
    }

    private void SetStats(CharacterName charName)
    {
        maxHP = charStats[charName].hp;
        speed = charStats[charName].speed;
        abilityCooldown = charStats[charName].abilityCooldown;
        hpRegen = charStats[charName].hpRegen;

        attackSpeed = charStats[charName].attackSpeed;
        damage = charStats[charName].damage;
        projectileSpeed = charStats[charName].projectileSpeed;
        projectileDuration = charStats[charName].projectileDuration;
        projectileArea = charStats[charName].projectileArea;
    }

    private void InstantiateDict()
    {//AtkSpeed is more like AttackTimer i.e atkSpeed 5 means they will swing their weapon every 5 seconds
        //It's prob a good idea to make things like AtkSpeed here a stat like 1.2 then have a base attack speed stat for weapons
        //Then when they get a buff thats +20% attack speed we can apply it as * 1.2 to this stat
        //PC's
        charStats.Add(CharacterName.TempChar, new StatConstructor
            (health: 100, healthRegen: .2f, spd: 3, 
            abilityCD: 1, atkSpeed: 1, dmg: 1, projSpeed: 1, projDur: 1, projArea: 1));



        //Enemies
        charStats.Add(CharacterName.Zombie, new StatConstructor
            (health: 25, healthRegen: 0, spd: 2f, 
            abilityCD: 1, atkSpeed: 1, dmg: 5, projSpeed: 1, projDur: 1, projArea: 1));

        charStats.Add(CharacterName.TankyZombie, new StatConstructor
            (health: 55, healthRegen: 0, spd: 1.5f, 
            abilityCD: 1, atkSpeed: 1, dmg: 10, projSpeed: 1, projDur: 1, projArea: 1));


        SetStats(charName);
    }

    public void ChangeHP(float dmgTaken)
    {
        if (dmgTaken < 0 && currentHP >= maxHP) return; //If dmg taken is healing and our current HP is capped, return
        
        currentHP -= dmgTaken;
        if (currentHP > maxHP) currentHP = maxHP;
        print(currentHP + "/" + maxHP);
    }
}

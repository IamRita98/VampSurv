using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public float hp;
    public float speed;

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
    }

    private void SetStats(CharacterName charName)
    {
        hp = charStats[charName].hp;
        speed = charStats[charName].speed;

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
            (health: 100, spd: 3, atkSpeed: 1, dmg: 1, projSpeed: 1, projDur: 1, projArea: 1));



        //Enemies
        charStats.Add(CharacterName.Zombie, new StatConstructor
            (health: 25, spd: 2f, atkSpeed: 1, dmg: 5, projSpeed: 1, projDur: 1, projArea: 1));
        charStats.Add(CharacterName.TankyZombie, new StatConstructor
    (health: 55, spd: 1.5f, atkSpeed: 1, dmg: 10, projSpeed: 1, projDur: 1, projArea: 1));


        SetStats(charName);
    }

    public void ChangeHP(float dmgTaken)
    {
        hp -= dmgTaken;
        print(hp);
    }
}

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
        FillerChar
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
    {
        //hp, speed
        charStats.Add(CharacterName.TempChar, new StatConstructor(health: 100, spd: 3, atkSpeed: 5, dmg: 10, projSpeed: 3, projDur: 1, projArea: 1));

        SetStats(charName);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public float currentHP;
    public float maxHP;
    public float hpRegen;
    public float invincibilityTimer;
    public float intensity;
    public float speed;
    public float abilityCooldown;

    public float attackSpeed;
    public float projectileSpeed;
    public float duration;
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

    bool isHurt;
    private void Update()
    {
        if (currentHP < maxHP) isHurt = true;
        else isHurt = false;

        if (!isHurt) return;
        HPRegen();
    }

    private void SetStats(CharacterName charName)
    {
        maxHP = charStats[charName].hp;
        invincibilityTimer = charStats[charName].invinciblityTimer;
        speed = charStats[charName].speed;
        intensity = charStats[charName].intensity;
        abilityCooldown = charStats[charName].abilityCooldown;
        hpRegen = charStats[charName].hpRegen;

        attackSpeed = charStats[charName].attackSpeed;
        projectileSpeed = charStats[charName].projectileSpeed;
        duration = charStats[charName].duration;
        projectileArea = charStats[charName].projectileArea;
    }

    private void InstantiateDict()
    {
        charStats.Add(CharacterName.TempChar, new StatConstructor
            (health: 100, healthRegen: .2f, invincTimer: .5f, dmgIntensity: 1,  spd: 2.5f,
            abilityCD: 1, atkSpeed: 1, projSpeed: 1, dur: 1, projArea: 1));



        //Enemies
        charStats.Add(CharacterName.Zombie, new StatConstructor
            (health: 25, healthRegen: 0, invincTimer: 0, dmgIntensity: 5, spd: 1.25f,
            abilityCD: 1, atkSpeed: 1, projSpeed: 1, dur: 1, projArea: 1));

        charStats.Add(CharacterName.TankyZombie, new StatConstructor
            (health: 55, healthRegen: 0, invincTimer: 0,  dmgIntensity: 10, spd: .9f,
            abilityCD: 1, atkSpeed: 1, projSpeed: 1, dur: 1, projArea: 1));


        SetStats(charName);
    }

    void HPRegen()
    {
        ChangeHP(-hpRegen * Time.deltaTime);
    }

    /// <summary>
    /// Change current hp, pass a negative number for healing
    /// </summary>
    /// <param name="dmgTaken"></param>
    public void ChangeHP(float dmgTaken)
    {
        if (dmgTaken < 0 && currentHP >= maxHP) return; //If dmg taken is healing and our current HP is capped, return

        currentHP -= dmgTaken;
        if (currentHP > maxHP) currentHP = maxHP;
        if(dmgTaken >= 1)
        {
            print(currentHP + "/" + maxHP);
        }

    }

    public void ChangeHPRegen(float amountToChange)
    {
        hpRegen += amountToChange;
    }

    /// <summary>
    /// Change base dmg of Char. This is percentage base so number passed should be 1.2 for 20% more or .8 for 20% less
    /// </summary>
    /// <param name="amountToChange"></param>
    public void ChangeIntensity(float amountToChange)
    {
        intensity *= amountToChange;
    }
    public void ChangeIntensityFlat(float amountToChange)
    {
        intensity += amountToChange;
    }
}

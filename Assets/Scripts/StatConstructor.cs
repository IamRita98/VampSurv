using UnityEngine;

public class StatConstructor
{
    //Character stats
    public float hp;
    public float hpRegen;
    public float speed;
    public float abilityCooldown;

    //Weapon stats
    public float attackSpeed;
    public float damage;
    public float projectileSpeed;
    public float projectileDuration;
    public float projectileArea;

    public StatConstructor(float health, float healthRegen, float spd, float abilityCD, float atkSpeed, float dmg, float projSpeed, float projDur, float projArea)
    {
        hp = health;
        hpRegen = healthRegen;
        speed = spd;
        abilityCooldown = abilityCD;
        
        attackSpeed = atkSpeed;
        damage = dmg;
        projectileSpeed = projSpeed;
        projectileDuration = projDur;
        projectileArea = projArea;
    }
}

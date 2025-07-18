using UnityEngine;

public class StatConstructor
{
    //Character stats
    public float hp;
    public float hpRegen;
    public float speed;
    public float abilityCooldown;
    public float intensity;

    //Weapon stats
    public float attackSpeed;
    public float projectileSpeed;
    public float duration;
    public float projectileArea;

    public StatConstructor(float health, float healthRegen, float spd, float abilityCD, float dmgIntensity, float atkSpeed, float projSpeed, float dur, float projArea)
    {
        hp = health;
        hpRegen = healthRegen;
        speed = spd;
        abilityCooldown = abilityCD;
        intensity = dmgIntensity;
        
        attackSpeed = atkSpeed;
        projectileSpeed = projSpeed;
        duration = dur;
        projectileArea = projArea;
    }
}

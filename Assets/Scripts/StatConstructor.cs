using UnityEngine;

public class StatConstructor
{
    //Character stats
    public float hp;
    public float hpRegen;
    public float invinciblityTimer;
    public float speed;
    public float abilityCooldown;
    public float intensity;

    //Weapon stats
    public float attackSpeed;
    public float projectileSpeed;
    public float duration;
    public float projectileArea;

    public StatConstructor(float health, float healthRegen, float invincTimer, float spd, float abilityCD, float dmgIntensity, float atkSpeed, float projSpeed, float dur, float projArea)
    {
        hp = health;
        hpRegen = healthRegen;
        invinciblityTimer = invincTimer;
        speed = spd;
        abilityCooldown = abilityCD;
        intensity = dmgIntensity;
        
        attackSpeed = atkSpeed;
        projectileSpeed = projSpeed;
        duration = dur;
        projectileArea = projArea;
    }
}

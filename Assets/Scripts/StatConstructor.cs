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
    public float pickupRadius;

    //Weapon stats
    public float attackSpeed;
    public float projectileSpeed;
    public float duration;
    public float attackArea;

    public StatConstructor(float health, float healthRegen, float invincTimer, float spd, float abilityCD, float dmgIntensity, float pickupSize, float atkSpeed, float projSpeed, float dur, float atkArea)
    {
        hp = health;
        hpRegen = healthRegen;
        invinciblityTimer = invincTimer;
        speed = spd;
        abilityCooldown = abilityCD;
        intensity = dmgIntensity;
        pickupRadius = pickupSize;
        
        attackSpeed = atkSpeed;
        projectileSpeed = projSpeed;
        duration = dur;
        attackArea = atkArea;
    }
}

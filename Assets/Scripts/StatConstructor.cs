using UnityEngine;

public class StatConstructor
{
    //Character stats
    public float hp;
    public float speed;

    //Weapon stats
    public float attackSpeed;
    public float damage;
    public float projectileSpeed;
    public float projectileDuration;
    public float projectileArea;
    public StatConstructor(float health, float spd, float atkSpeed, float dmg, float projSpeed, float projDur, float projArea)
    {
        hp = health;
        speed = spd;
        
        attackSpeed = atkSpeed;
        damage = dmg;
        projectileSpeed = projSpeed;
        projectileDuration = projDur;
        projectileArea = projArea;
    }
}

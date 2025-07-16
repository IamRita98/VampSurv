using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    public float attackSpeed;
    public float damage;
    public float projectileSpeed;
    public float projectileDuration;
    public float projectileArea;

    public WeaponStats(float atkSpeed, float dmg, float projSpeed, float projDur, float projArea)
    {
        attackSpeed = atkSpeed;
        damage = dmg;
        projectileSpeed = projSpeed;
        projectileDuration = projDur;
        projectileArea = projArea;
    }
}

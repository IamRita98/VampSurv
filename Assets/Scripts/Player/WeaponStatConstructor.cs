using UnityEngine;

public class WeaponStatConstructor
{
    public float weaponFireRate;
    public float weaponDmg;
    public float weaponProjSpeed;
    public float weaponProjDur;
    public float weaponProjArea;
    public WeaponStatConstructor(float atkSpeed, float dmg, float projSpeed, float projDur, float projArea)
    {
        weaponFireRate = atkSpeed;
        weaponDmg = dmg;
        weaponProjSpeed = projSpeed;
        weaponProjDur = projDur;
        weaponProjArea = projArea;
    }
}

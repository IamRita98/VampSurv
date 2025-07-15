using UnityEngine;

[RequireComponent(typeof(SpriteFlipper))]
public class ChangeWeaponPosition : MonoBehaviour
{
    private Transform weaponPosR;
    private Transform weaponPosL;
    private GameObject weapon;

    private void Start()
    {
        weapon = transform.GetChild(0).GetChild(0).gameObject;
        weaponPosR = transform.GetChild(0).GetChild(1);
        weaponPosL = transform.GetChild(0).GetChild(2);

        weapon.transform.position = weaponPosR.position;
    }

    public void WeaponOnRightSide()
    {
        weapon.transform.position = weaponPosR.position;
    }

    public void WeaponOnLeftSide()
    {
        weapon.transform.position = weaponPosL.position;
    }
}

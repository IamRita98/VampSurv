using UnityEngine;

[RequireComponent(typeof(SpriteFlipper))]
public class ChangeWeaponPosition : MonoBehaviour
{
    public Transform weaponPosR;
    public Transform weaponPosL;
    public GameObject weapon;
    //This script will become irrelevent if I make a sprite w/ the weapon attached to it. Sprite Flipper will just put the weap on the other side
    //But for now I like how it looks :)

    private void Start()
    {
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

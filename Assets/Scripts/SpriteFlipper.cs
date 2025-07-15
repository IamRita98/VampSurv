using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    Vector3 target;
    bool isFlipped;
    GetMousePos mousePos;
    SpriteRenderer sRend;
    string attachedGO;
    ChangeWeaponPosition cWepPos;

    private void Start()
    {
        CheckAttachedGO();
        mousePos = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GetMousePos>();
        cWepPos = GetComponent<ChangeWeaponPosition>();
    }

    private void Update()
    {
        FlipSprite();
    }

    private void FlipSprite()
    {
        if(attachedGO == "Player")
        {
            target = mousePos.mousePos;
        }

        if (!isFlipped && transform.position.x > target.x)
        {
            sRend.flipX = true;
            isFlipped = true;
            cWepPos.WeaponOnLeftSide();
            Debug.Log("Flipped");
        }
        else if(isFlipped && transform.position.x < target.x)
        {
            sRend.flipX = false;
            isFlipped = false;
            cWepPos.WeaponOnRightSide();
            Debug.Log("Unflipped");
        }
    }

    private void CheckAttachedGO()
    {
        if (gameObject.CompareTag("Player"))
        {
            attachedGO = "Player";
            sRend = gameObject.GetComponentInChildren<SpriteRenderer>();
        }
    } 
}

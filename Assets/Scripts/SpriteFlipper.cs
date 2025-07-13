using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    Vector3 target;
    GetMousePos mousePos;
    SpriteRenderer sRend;
    string attachedGO;

    private void Start()
    {
        CheckAttachedGO();
        mousePos = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GetMousePos>();
    }

    private void Update()
    {
        FlipSprite();
    }

    private void FlipSprite()
    {
        if(attachedGO == "player")
        {
            target = mousePos.mousePos;
        }

        if (transform.position.x > target.x) sRend.flipX = true;
        else sRend.flipX = false; 
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

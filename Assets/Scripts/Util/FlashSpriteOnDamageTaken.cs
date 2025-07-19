using UnityEngine;

public class FlashSpriteOnDamageTaken : MonoBehaviour
{
    SpriteRenderer sRend;
    float internalTimer;
    float flashDuration;
    bool startTimer = false;
    Color startingColor;
    Color flashColor;
    bool startingColorIsSet;

    private void Update()
    {
        if (sRend == null) return;
        if (startTimer)
        {
            internalTimer += Time.deltaTime;
        }

        if(internalTimer >= flashDuration)
        {
            startTimer = false;
            internalTimer = 0;
            sRend.color = startingColor;
            startingColorIsSet = false;
        }
    }

    public void FlashEnemySprite()
    {
        sRend = GetComponent<SpriteRenderer>();
        if (!startingColorIsSet)
        {
            startingColor = sRend.color;
            startingColorIsSet = true;
        }
        flashDuration = .15f;
        flashColor = new Color(1, .75f, .75f);
        sRend.color = flashColor;
        startTimer = true;
    }

    public void FlashPlayerSprite()
    {
        sRend = GetComponent<SpriteRenderer>();
        if (!startingColorIsSet)
        {
            startingColor = sRend.color;
            startingColorIsSet = true;
        }
        flashDuration = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>().invincibilityTimer;
        flashColor = new Color(1, .4f, .4f);
        sRend.color = flashColor;
        startTimer = true;
    }
}

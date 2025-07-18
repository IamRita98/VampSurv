using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
[RequireComponent(typeof(SpriteFlipper))]
public class PlayerController : MonoBehaviour
{
    private Vector2 input;
    private Rigidbody2D rb;

    private CharacterStats cStats;

    float abilityOneCooldownTimer;
    bool abilityOneIsOnCooldown = false;
    float abilityTwoCooldownTimer;
    bool abilityTwoIsOnCooldown = false;

    float tempCharWhirlwindAbilityBaseCooldown = 6;
    float tempCharRegenAndDamageBuffBaseCooldown = 15;

    float tempCharWhirlwindAbilityCooldown;
    float tempCharRegenAndDamageBuffCooldown;

    float abilityOneCooldown;
    float abilityTwoCooldown;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cStats = GetComponent<CharacterStats>();

        SetAbilityOneCooldowns();
        SetAbilityTwoCooldowns();
        

        SetCharactersAbilityToCooldownsVariable();
    }

    private void Update()
    {
        Movement();
        TrackCooldowns();
        AbilityInput();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = input * cStats.speed;
    }

    void Movement()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input.Normalize();
    }

    void AbilityInput()
    {
        if (Input.GetKey(KeyCode.Mouse0) && !abilityOneIsOnCooldown)
        {
            abilityOneIsOnCooldown = true;
            abilityOneCooldownTimer = 0;
            SetAbilityOneCooldowns();
            UseAbilityOne();
        }

        if (Input.GetKey(KeyCode.Mouse1) && !abilityTwoIsOnCooldown)
        {
            abilityTwoIsOnCooldown = true;
            abilityTwoCooldownTimer = 0;
            SetAbilityTwoCooldowns();
            UseAbilityTwo();
        }
    }

    void SetAbilityOneCooldowns()
    {
        switch (cStats.charName)
        {
            case CharacterStats.CharacterName.TempChar:
                abilityOneCooldown = tempCharWhirlwindAbilityBaseCooldown * cStats.abilityCooldown;
                break;
        }
    }

    public GameObject tempCharWhirlwind;
    void UseAbilityOne()
    {
        switch (cStats.charName)
        {
            case CharacterStats.CharacterName.TempChar:
                Instantiate(tempCharWhirlwind, transform.position, Quaternion.identity, gameObject.transform);
                break;
        }
    }

    void SetAbilityTwoCooldowns()
    {
        switch (cStats.charName)
        {
            case CharacterStats.CharacterName.TempChar:
                abilityTwoCooldown = tempCharRegenAndDamageBuffBaseCooldown * cStats.abilityCooldown;
                break;
        }
    }

    public GameObject tempCharRegenAndDamageBuff;
    void UseAbilityTwo()
    {
        switch (cStats.charName)
        {
            case CharacterStats.CharacterName.TempChar:
                Instantiate(tempCharRegenAndDamageBuff, transform.position, Quaternion.identity, gameObject.transform);
                break;
        }
    }

    void TrackCooldowns()
    {
        if (abilityOneIsOnCooldown)
        {
            abilityOneCooldownTimer += Time.deltaTime;
            if (abilityOneCooldownTimer >= abilityOneCooldown)
            {
                abilityOneIsOnCooldown = false;
            }
        }

        if (abilityTwoIsOnCooldown)
        {
            abilityTwoCooldownTimer += Time.deltaTime;
            if (abilityTwoCooldownTimer >= abilityTwoCooldown)
            {
                abilityTwoIsOnCooldown = false;
            }
        }
    }

    void SetCharactersAbilityToCooldownsVariable()
    {
        switch (cStats.charName)
        {
            case CharacterStats.CharacterName.TempChar:
                abilityOneCooldown = tempCharWhirlwindAbilityCooldown;
                abilityTwoCooldown = tempCharRegenAndDamageBuffCooldown;
                break;
        }
    }
}

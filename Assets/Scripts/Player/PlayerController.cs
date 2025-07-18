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

    float whirlwindAbilityBaseCooldown = 6;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cStats = GetComponent<CharacterStats>();

        float whirlwindAbilityCooldown = whirlwindAbilityBaseCooldown * cStats.abilityCooldown;
    }

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input.Normalize();

        if (abilityOneIsOnCooldown)
        {
            abilityOneCooldownTimer += Time.deltaTime;
            if(abilityOneCooldownTimer >= whirlwindAbilityBaseCooldown)
            {
                abilityOneIsOnCooldown = false;
            }
        }

        if (Input.GetKey(KeyCode.Mouse0) && !abilityOneIsOnCooldown)
        {
            abilityOneIsOnCooldown = true;
            abilityOneCooldownTimer = 0;
            UseAbilityOne();
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            UseAbilityTwo();
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = input * cStats.speed;
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

    void UseAbilityTwo()
    {
        switch (cStats.charName)
        {
            case CharacterStats.CharacterName.TempChar:
                break;
        }
    }
}

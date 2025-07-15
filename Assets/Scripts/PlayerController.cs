using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
[RequireComponent(typeof(SpriteFlipper))]
public class PlayerController : MonoBehaviour
{
    private Vector2 input;
    private Rigidbody2D rb;

    private CharacterStats cStats;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input.Normalize();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = input * cStats.speed;
    }
}

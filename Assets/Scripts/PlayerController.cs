using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Stats))]
[RequireComponent(typeof(SpriteFlipper))]
public class PlayerController : MonoBehaviour
{
    private Vector2 input;
    private Rigidbody2D rb;

    private Stats stats;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<Stats>();
    }

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input.Normalize();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = input * stats.speed;
    }
}

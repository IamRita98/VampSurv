using UnityEngine;

public class GetPlayerPos : MonoBehaviour
{
    Vector2 playerPos;

    private void Update()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}

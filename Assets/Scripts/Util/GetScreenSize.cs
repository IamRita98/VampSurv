using UnityEngine;

public class GetScreenSize : MonoBehaviour
{
    public float screenHeight;
    public float screenWidth;
    Camera cam;

    private void Awake()
    {
        cam = Camera.main;
        screenHeight = cam.orthographicSize * 2f;
        screenWidth = screenHeight * cam.aspect;
    }
}

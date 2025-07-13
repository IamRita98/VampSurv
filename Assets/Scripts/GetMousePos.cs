using UnityEngine;

public class GetMousePos : MonoBehaviour
{
    Camera cam;
    public Vector3 mousePos;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
    }
}

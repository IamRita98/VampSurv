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

    public Quaternion LookAtMouse(Vector3 lookerPos)
    {
        Vector2 dir = mousePos - lookerPos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion targetRot = Quaternion.AngleAxis(angle, Vector3.forward);
        return targetRot;
    }
}

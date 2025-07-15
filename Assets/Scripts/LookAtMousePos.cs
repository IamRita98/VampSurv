using UnityEngine;

public class LookAtMousePos : MonoBehaviour
{
    GetMousePos mousePos;

    private void Start()
    {
        mousePos = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GetMousePos>();
    }

    public Quaternion LookAtMouse(Vector3 lookerPos)
    {
        Vector2 dir = mousePos.mousePos - lookerPos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion targetRot = Quaternion.AngleAxis(angle, Vector3.forward);
        return targetRot;
    }
}

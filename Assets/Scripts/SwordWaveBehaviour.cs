using UnityEngine;

public class SwordWaveBehaviour : MonoBehaviour
{
    Timer timer;
    GetMousePos mousePos;

    Attacks atks;

    public Vector3 targetSize;

    private void Start()
    {
        atks = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Attacks>();

        timer = GetComponent<Timer>();
        mousePos = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GetMousePos>();

        Vector2 dir = mousePos.mousePos - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);



        transform.localScale = transform.localScale * atks.projectileArea;
        targetSize = new Vector3
            ((transform.localScale.x * .3f) * atks.projectileArea,
            (transform.localScale.y * 2) * atks.projectileArea,
            1);


        timer.SetTimer(atks.projectileDuration);
    }

    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetSize, atks.projectileDuration * Time.deltaTime);

        if (!timer.timerComplete) return;
        Destroy(this.gameObject);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * atks.projectileSpeed * Time.deltaTime);
    }
}

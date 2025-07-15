using UnityEngine;

[RequireComponent(typeof(LookAtMousePos))]
public class SwordWaveBehaviour : MonoBehaviour
{
    Timer timer;
    LookAtMousePos lookAtMousePos;

    Attacks atks;

    public Vector3 targetSize;

    private void Awake()
    {
        atks = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Attacks>();
        timer = GetComponent<Timer>();
        lookAtMousePos = GetComponent<LookAtMousePos>();
    }

    private void Start()
    {
        //Set starting rotation to look at mousePos
        transform.rotation = lookAtMousePos.LookAtMouse(transform.position);

        //Scale size of Spawned Sword Wave & it's target size w/ ProjArea
        transform.localScale = transform.localScale * atks.projectileArea;
        targetSize = new Vector3
            ((transform.localScale.x * .3f) * atks.projectileArea,
            (transform.localScale.y * 2) * atks.projectileArea,
            1);

        //Set timer to destroy self based on proj duration
        timer.SetTimer(atks.projectileDuration);
    }

    private void Update()
    {
        //increase length over lifespan
        transform.localScale = Vector3.Lerp(transform.localScale, targetSize, atks.projectileDuration * Time.deltaTime);

        if (!timer.timerComplete) return;
        Destroy(this.gameObject);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * atks.projectileSpeed * Time.deltaTime);
    }
}

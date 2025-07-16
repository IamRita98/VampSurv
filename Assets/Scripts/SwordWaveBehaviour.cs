using UnityEngine;

[RequireComponent(typeof(Timer))]
public class SwordWaveBehaviour : MonoBehaviour
{
    Timer timer;
    GetMousePos getMousePos;
    CharacterStats cStats;
    Vector3 targetSize;

    private void Awake()
    {
        cStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        timer = GetComponent<Timer>();
        getMousePos = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GetMousePos>();
    }

    private void Start()
    {
        //Set starting rotation to look at mousePos
        transform.rotation = getMousePos.LookAtMouse(transform.position);

        //Scale size of Spawned Sword Wave & it's target size w/ ProjArea
        transform.localScale = transform.localScale * cStats.projectileArea;
        targetSize = new Vector3
            ((transform.localScale.x * .3f) * cStats.projectileArea,
            (transform.localScale.y * 2) * cStats.projectileArea,
            1);

        //Set timer to destroy self based on proj duration
        timer.SetTimer(cStats.projectileDuration);
    }

    private void Update()
    {
        //increase length over lifespan
        transform.localScale = Vector3.Lerp(transform.localScale, targetSize, cStats.projectileDuration * Time.deltaTime);

        if (!timer.timerComplete) return;
        Destroy(this.gameObject);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * cStats.projectileSpeed * Time.deltaTime);
    }
}

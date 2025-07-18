using UnityEngine;

[RequireComponent(typeof(Timer))]
public class SwordWaveBehaviour : MonoBehaviour
{
    Timer timer;
    GetMousePos getMousePos;
    WeaponStats wStats;
    DealDamageToEnemy dealDamageToEnemy;
    Vector3 targetSize;
    Vector3 baseWepSize;

    private void Awake()
    {
        wStats = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponStats>();
        timer = GetComponent<Timer>();
        getMousePos = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GetMousePos>();
        dealDamageToEnemy = GetComponent<DealDamageToEnemy>();

        dealDamageToEnemy.damageToDeal = wStats.damage;
    }

    private void Start()
    {
        //Set starting rotation to look at mousePos
        transform.rotation = getMousePos.LookAtMouse(transform.position);

        //Set base size of sword wave then scale it based on wStats
        baseWepSize = new Vector3
            (transform.localScale.x,
            transform.localScale.y * wStats.projectileArea, //We only want to change the Y size from the prefab
            transform.localScale.z);
        transform.localScale = baseWepSize;

        targetSize = new Vector3
            ((transform.localScale.x * .3f), //Magic number is to make the wave skinnier as it travels for some flavor
            (transform.localScale.y * 2) * wStats.projectileArea, //Double it's length as it travels, multiply the total length by projArea
            1);

        //Set timer to destroy self based on proj duration
        timer.SetTimer(wStats.projectileDuration);
    }

    private void Update()
    {
        //increase length over lifespan
        transform.localScale = Vector3.Lerp(transform.localScale, targetSize, wStats.projectileDuration * Time.deltaTime);

        if (!timer.timerComplete) return;
        Destroy(this.gameObject);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * wStats.projectileSpeed * Time.deltaTime);
    }
}

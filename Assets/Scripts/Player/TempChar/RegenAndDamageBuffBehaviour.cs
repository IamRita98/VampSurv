using UnityEngine;

public class RegenAndDamageBuffBehaviour : MonoBehaviour
{
    CharacterStats cStats;
    WeaponStats wStats;
    Timer timer;
    GameObject player;

    private void Start()
    {
        timer = GetComponent<Timer>();

        player = GameObject.FindGameObjectWithTag("Player");
        cStats = player.GetComponent<CharacterStats>();
        wStats = player.GetComponent<WeaponStats>();
    }

    void RegenBuff()
    {

    }

    void DamageBuff()
    {

    }
}

using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public GameObject parentChar;
    public GameObject swordWave;
    Timer timer;

    CharacterStats cStats;
    WeaponStats wStats;

    void Start()
    {
        wStats = parentChar.GetComponent<WeaponStats>();
        cStats = parentChar.GetComponent<CharacterStats>();
        timer = GetComponent<Timer>();

        timer.SetTimer(wStats.attackSpeed);
    }

    private void Update()
    {
        if (!timer.timerComplete) return;
        timer.timerComplete = false;
        timer.SetTimer(wStats.attackSpeed);


        switch (cStats.charName)
        {
            case CharacterStats.CharacterName.TempChar:
                SwordAttack();
                break;
        }
    }

    private void SwordAttack()
    {
        GameObject instantiatedAttack = Instantiate(swordWave, transform.parent.position, Quaternion.identity);
    }
}

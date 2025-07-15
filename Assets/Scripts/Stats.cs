using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    
    public float hp;
    public float speed;

    public enum CharacterName 
    { 
        TempChar,
        FillerChar
    }
    public CharacterName charName;


    Dictionary<CharacterName, List<float>> charStats = new();

    private void Start()
    {
        InstantiateDict();
    }

    private void SetStats(CharacterName charName)
    {
        hp = charStats[charName][0];
        speed = charStats[charName][1];
    }

    private void InstantiateDict()
    {
        //hp, speed
        charStats.Add(CharacterName.TempChar, new List<float> { 100, 2.5f });

        SetStats(charName);
    }
}

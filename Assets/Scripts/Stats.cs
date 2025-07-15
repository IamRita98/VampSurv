using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public string charName;
    public float hp;
    public float speed;

    Dictionary<string, List<float>> charStats = new();

    private void Start()
    {
        InstantiateDict();
    }

    private void SetStats(string charName)
    {
        hp = charStats[charName][0];
        speed = charStats[charName][1];
    }

    private void InstantiateDict()
    {
        //hp, speed
        charStats.Add("TempChar", new List<float> { 100, 2.5f });

        SetStats(charName);
    }
}

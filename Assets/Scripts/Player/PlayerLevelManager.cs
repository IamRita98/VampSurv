using UnityEngine;

public class PlayerLevelManager : MonoBehaviour
{
    public int exp;
    public int currentLevel;

    public int expToNextLevel;
    public int baseExpToNextLevel = 10;

    private void Start()
    {
        expToNextLevel = baseExpToNextLevel;
    }

    private void OnEnable()
    {
        EXPPickupBehaviour.onExpPickedUp += ExpGained;
    }

    private void OnDisable()
    {
        EXPPickupBehaviour.onExpPickedUp -= ExpGained;
    }

    void ExpGained(int expGained)
    {
        exp += expGained;
        print("XP: " + exp);
        if(exp >= expToNextLevel)
        {
            LevelUp();
            exp -= expToNextLevel;
            ScaleExpToNextLevel();
        }
    }

    void LevelUp()
    {
        print("Leveled up!");
    }

    void ScaleExpToNextLevel()
    {
        //This will def need to be more complex
        expToNextLevel = (int)Mathf.Round(expToNextLevel * 1.2f);
        print("xp to next level: " + expToNextLevel);
    }
}
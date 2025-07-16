using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    public bool timerComplete;

    private void Update()
    {
        if (timerComplete) return;

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            timerComplete = true;
        }
    }

    public void SetTimer(float timerLength)
    {
        timeLeft = timerLength;
    }
}

/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using RTDK;
using UnityEngine;


/// <summary>
/// 
/// </summary>
public class Clock : TimerBase
{
    public override void HandleTimer()
    {
        currentTime += Time.deltaTime;

        if (time != -1 && currentTime >= time)
        {
            onTimerFinish.Invoke();
            StopTimer();
        }
    }

    public override void StartTimer(bool resume = false)
    {
        base.StartTimer(resume);
        currentTime = resume ? 0 : currentTime;
    }
}

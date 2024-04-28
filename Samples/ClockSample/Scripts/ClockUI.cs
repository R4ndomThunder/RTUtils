/**
*   MIT License
*
*   Samuele Padalino @R4ndomThunder
*   https://samuelepadalino.dev
*/

using RTDK;
using System;
using UnityEngine;


/// <summary>
/// 
/// </summary>
public class ClockUI : TimerUIBase
{
    public override void ShowTimer()
    {
        base.ShowTimer();
        var t = timerToShow.GetCurrentTime();
        var tParsed = TimeSpan.FromSeconds(t);

        timerText.text = $"{tParsed.Hours:00}:{tParsed.Minutes:00}:{tParsed.Seconds:00}.{tParsed.Milliseconds:000}";
    }
}

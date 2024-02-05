using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameClock : MonoBehaviour
{
    int timer;
    TMP_Text displayeTimer;

    private void Awake()
    {
        timer = 0;
        displayeTimer = GetComponent<TMP_Text>();
    }

    void Update()
    {
        timer = ((int)Time.time);
        DisplayTimer();
    }

    private void DisplayTimer()
    {
        displayeTimer.text = "Clock " + timer.ToString();
    }
}

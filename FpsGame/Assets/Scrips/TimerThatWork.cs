using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerThatWork : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float timerTime = 0f;
    private bool timerPlaying = true;

    private void Start()
    {
        timerTime = Time.timeSinceLevelLoad;
    }

    private void Update()
    {
        if (timerPlaying)
        {
            timerTime += Time.deltaTime;
            UpdateTimerDisplay();
            Debug.Log("The Time Is" + timerText);
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timerTime / 60f);
        int seconds = Mathf.FloorToInt(timerTime % 60f);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = "Time: " + timeString;
    }
}
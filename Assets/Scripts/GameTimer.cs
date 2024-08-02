using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameTimer : MonoBehaviour
{
    [SerializeField]
    private float setTime;
    private float timer;
    [SerializeField]
    TMP_Text timeText;

    [SerializeField]
    TMP_Text countDownText;

    private bool startTimer=false;

    void Start()
    {
        timer=setTime;
        StartCoroutine(StartTimer());
    }

    void Update()
    {
        if (timer > 0 && startTimer)
        {
            timer-=Time.deltaTime;
            timeText.text=ConvertTimeToString(timer);
        }
    }

    string ConvertTimeToString(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60); // Get the minutes
        int seconds = Mathf.FloorToInt(totalSeconds % 60); // Get the remaining seconds

        // Format the string to display minutes and seconds
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator StartTimer()
    {
        countDownText.text="3";
        yield return new WaitForSeconds(1.0f);

        countDownText.text="2";
        yield return new WaitForSeconds(1.0f);

        countDownText.text="1";
        yield return new WaitForSeconds(1.0f);

        countDownText.text="Go";
        yield return new WaitForSeconds(0.5f);

        countDownText.gameObject.SetActive(false);
        startTimer=true;
    }
}

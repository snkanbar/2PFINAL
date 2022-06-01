using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    float cntdnw = 120.0f;
    public Text disvar;

    void Update()
    {
        if (cntdnw > 0)
        {
            cntdnw -= Time.deltaTime;
        }
        double b = System.Math.Round(cntdnw, 2);
        disvar.text = b.ToString();
        if (cntdnw < 0)
        {
            Debug.Log("Completed");
        }
    }
}
/*{
    public Text TimerText;
    public bool playing;
    private float _timer;
    public float timeValue = 90;

    void Update()
    {

        if (playing == true)
        {

            _timer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeValue / 60f);
            int seconds = Mathf.FloorToInt(timeValue % 60f);
            //int milliseconds = Mathf.FloorToInt((_timer * 100F) % 100F);
            TimerText.text = minutes.ToString("60") + ":" + seconds.ToString("60");
            //TimerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
        }

    }

}/*
/*{
    public float timeValue = 90;
    public Text timerText;

    //Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }

        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = timeToDisplay % 1 * 1000;

        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);

    }
}*/
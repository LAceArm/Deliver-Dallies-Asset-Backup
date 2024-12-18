using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    private float timer;
    private bool isFlowing = true;
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        timer = 301; 
        timerText.gameObject.SetActive(true);
        timerText.text = "Time Left: " + timer.ToString();
  
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = "Time Left: " + ((int)(timer)).ToString();
        while (timer > 0 && isFlowing)
        {
            timer=timer-Time.deltaTime;
        }
    }
    public int getTime()
    {
        return (int)(timer);
    }
    public void setTime(float newTime)
    {
        timer = newTime;
    }
    public void timeIsFlowing(bool condition)
    {
        isFlowing = condition;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointCalculator : MonoBehaviour
{
    public GameObject deliveryBoy;
    public GameObject timer;
    public TextMeshProUGUI pointText;
    private int startHealth = 20;
    private int startTime = 300;
    private int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        pointText.gameObject.SetActive(true);
        SetPointText();
    }

 
   public void calculatePoints()
    {
        timer.GetComponent<TimerScript>().timeIsFlowing(false);
        int time=timer.GetComponent<TimerScript>().getTime();
        int health=deliveryBoy.GetComponent<DeliveryManController>().getHealth();
        int timePoints = startTime - time;
        int healthPoints=startHealth - health;
        points += (timePoints + healthPoints);
        SetPointText();
        deliveryBoy.GetComponent<DeliveryManController>().setHealth(healthPoints);

    }
    void SetPointText()
    {
        pointText.text= "Points: "+points.ToString();
    }
    public int getPoints() { return points; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeliveryDone : MonoBehaviour
{
    public GameObject pointCalculator;
    public GameObject timer;
    public Transform player;
    public Transform deliveryBoy;
    public TextMeshProUGUI helpText;
    private static int deliveriesDone = 0;
    void Start()
    {
        helpText.gameObject.SetActive(false);
    }
    void Update()
    {
        float distancefromPlayer=Vector3.Distance(transform.position, player.position);
        float distanceBetweenPlayerAndDelivery = Vector3.Distance(player.position, deliveryBoy.position);
        int numTimesCalculated = 0;
        if (distancefromPlayer < 15)
        {
            timer.GetComponent<TimerScript>().timeIsFlowing(false);
        }
        else if (distancefromPlayer < 15 & distanceBetweenPlayerAndDelivery < 5 && numTimesCalculated==0)
        {
            helpText.gameObject.SetActive(true);
            helpText.text = "Click and Press D to make a delivery";
            numTimesCalculated++;
            deliveriesDone++;

            pointCalculator.GetComponent<PointCalculator>().calculatePoints();
        }
        if(deliveriesDone >= 4)
        {
            Debug.Log("Game Complete.");
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
public class DeliveryManController : MonoBehaviour
{
    public Transform player;
    public AudioClip onHit;
    public TextMeshProUGUI healthText;
    private AudioSource source;
    private NavMeshAgent navMeshAgent;
    private float eyesight;
    private float distanceToPlayer;
    private Vector3 stopAt;
    private int hitpoints = 15;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        eyesight = 20f;
        stopAt=new Vector3 (2,0,2);
        source = GetComponent<AudioSource>();
        healthText.gameObject.SetActive(true);
        SetHealthText();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(player.position,transform.position);
        if (player != null && distanceToPlayer<=eyesight) //Don't tread too far, otherwise he won't know where to go
        {
            navMeshAgent.SetDestination(player.position-stopAt);
        }
    }
    void onCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            source.PlayOneShot(onHit,0.7f);
            hitpoints--;
            SetHealthText();
        }
    }
    public void setHealth(int heal) 
    {
        hitpoints += heal;
        SetHealthText();
    }
    public int getHealth() 
    {
        return hitpoints; 
    }
    void SetHealthText()
    {
        healthText.text = "Health: " + hitpoints.ToString();
    }
}

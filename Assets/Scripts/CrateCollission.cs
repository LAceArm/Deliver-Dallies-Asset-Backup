using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
[RequireComponent(typeof(AudioSource))]
public class CrateCollission : MonoBehaviour
{
    public GameObject player;
    private float thresh=10.0f;
    AudioSource audioSource;
    NavMeshAgent navMeshAgent;
    public AudioClip breakCrate;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
     
     
    }
    void Update()
    {
      float distance=Vector3.Distance(player.transform.position,transform.position);
        if (distance < thresh) { 
            navMeshAgent.SetDestination(player.transform.position+Vector3.up);
        }
        if (distance < 2.0) 
        {
            Destroy(gameObject);
            player.GetComponent<AmmoCounter>().SetShots((player.GetComponent<AmmoCounter>().GetShots())+3);
            audioSource.PlayOneShot(breakCrate, 0.7f);
        }
    }


}

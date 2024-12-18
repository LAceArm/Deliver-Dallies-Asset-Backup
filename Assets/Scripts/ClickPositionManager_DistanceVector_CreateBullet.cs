using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class ClickPositionManager_DistanceVector_CreateBullet : MonoBehaviour
{
    public float distance = 10f;
    public float distanceChange = 1f;
    public float rotationAmount = 0f;
    public float rotationDelta = 0.0f;
    public GameObject bullet;
    float posX = -1f;
    float posY = -1f;
    float posZ = -1f;
    float launchVelocity = 360f;
    public GameObject magazine;
    public GameObject shell;
    AudioSource source;
    private bool shotgunActive;
    public AudioClip fire;
    public AudioClip shotgun;
    public AudioClip empty;
    public GameObject emptyDialogue;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        shotgunActive = false;
        emptyDialogue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        int numShots = magazine.GetComponent<AmmoCounter>().GetShots();
        if((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && numShots!=0)
        {
            distance += distanceChange;
            posX = -1f;
            posY = -1f;
            posZ = -1f;
            Vector3 clickPosition=new Vector3(posX, posY, posZ);
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, distanceChange));
            Debug.Log(clickPosition);
            rotationAmount += rotationDelta;
            Instantiate(bullet);
            source.PlayOneShot(fire, 0.7f);
            bullet.GetComponent<Rigidbody>().AddForce(new Vector3(launchVelocity,0f,0f));
            numShots = numShots - 1;
            magazine.GetComponent<AmmoCounter>().SetShots(numShots);

        }
        else if((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && numShots == 0)
        {
            source.PlayOneShot(empty, 0.7f);
            emptyDialogue.SetActive(true);
        }
        if (shotgunActive && (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && Input.GetKeyDown("s"))
        {
            distance += distanceChange;
            posX = -1f;
            posY = -1f;
            posZ = -1f;
            Vector3 clickPosition = new Vector3(posX, posY, posZ);
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, distanceChange));
            Debug.Log(clickPosition);
            rotationAmount += rotationDelta;
            Instantiate(shell);
            source.PlayOneShot(shotgun, 0.7f);
            shell.GetComponent<Rigidbody>().AddForce(new Vector3(launchVelocity,10f,0f));
            magazine.GetComponent<AmmoCounter>().SetShotgunAmmo(1);
        }
        
    }
    public void setShotGunActive() 
    { 
        shotgunActive = true;
        magazine.GetComponent<AmmoCounter>().SetShotGunTextActive();
    }
}

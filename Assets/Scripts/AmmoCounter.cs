using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoCounter : MonoBehaviour
{
    public TextMeshProUGUI ammoCounterText;
    public TextMeshProUGUI shotGunText;
    private int shots=12;
    private int shotgunShells = 15;
    // Start is called before the first frame update
    void Start()
    {
        ammoCounterText.gameObject.SetActive(true);
        shotGunText.gameObject.SetActive(true);
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetShots(int ammoCount) 
    {
        shots = ammoCount;
        SetCountText();
    }
    public int GetShots() { return shots; }
    void SetCountText()
    {
        ammoCounterText.text = "Shots: " + shots.ToString();
    }
    void SetShotGunText()
    {
        shotGunText.text="Shells Left: "+shotgunShells.ToString();
    }
    public int GetShotGunShots() { return shotgunShells; }
    public void SetShotGunTextActive() 
    { 
        shotGunText.gameObject.SetActive(true);
        SetShotGunText();
    }   

    public void SetShotgunAmmo(int shellCount) 
    { 
        shotgunShells-=shellCount; 
        SetShotGunText();
    }
}

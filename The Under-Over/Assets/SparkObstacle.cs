using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    public float activeSec;
    public float resetSec;
    float timer;
    bool isArmed;
    [SerializeField] BoxCollider dmgBox;
    [SerializeField] ParticleSystem sparkEmitter;
    void Start()
    {
        timer = resetSec;
        TurnOff(); // get into the loop
    }



    void TurnOn()
    {
        isArmed = true;
        dmgBox.enabled = true;
        sparkEmitter.Play();
        Invoke("TurnOff", activeSec);
    }
    void TurnOff()
    {
        isArmed = false;
        dmgBox.enabled = false;
        sparkEmitter.Stop();
        Invoke("TurnOn", resetSec);
    }
    
}

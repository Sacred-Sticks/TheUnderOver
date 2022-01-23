using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SparkObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    public float activeSec;
    public float resetSec;
    float timer;
    [SerializeField] float penalty;
    //bool isArmed;
    [SerializeField] Collider dmgBox;
    [SerializeField] ParticleSystem sparkEmitter;

    Movement playerMovement;
    void Awake()
    {
        playerMovement = GameObject.Find("Player").GetComponent<Movement>();
        timer = resetSec;
        float activationOffset = Random.Range(0, activeSec);
        Invoke("TurnOn", activationOffset); // get into the loop but stagger the emitters
    }



    void TurnOn()
    {
        //isArmed = true;
        dmgBox.enabled = true;
        sparkEmitter.Play();
        Invoke("TurnOff", activeSec);
    }
    void TurnOff()
    {
        //isArmed = false;
        dmgBox.enabled = false;
        sparkEmitter.Stop();
        Invoke("TurnOn", resetSec);
    }

    private void OnTriggerEnter(Collider col) {
        if (col.tag == "Player") {

            //SceneManager.LoadScene("Culling 2");
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            //SceneManager.LoadScene("Culling 2");
            
        }
    }

}

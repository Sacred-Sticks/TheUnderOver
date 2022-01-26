using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirlockControl : MonoBehaviour
{

    bool[] activated;
    public Animator[] animators; // endgame level animators, use get bool
    public float airlockdelaytime;

    [SerializeField] private GameObject endUI;
    [SerializeField] private GameObject pauseUI;

    [SerializeField] private GameObject[] airlockDoors;
    [SerializeField] private Rigidbody playerRB;

    private bool complete;
    private bool doorsOpen;
    private int remaining;
    private void Awake()
    {
        activated = new bool[animators.Length]; // the animator of each lever, needed to activate the conditional
        complete = false;
        endUI.SetActive(false);
        doorsOpen = false;
        remaining = animators.Length;
    }

    public void UpdateConditional(int seq, bool activeState)
    {
        activated[seq] = activeState;
        // now check to see if enabling / disabling this lever got us anywhere...
        for (int i = 0; i < animators.Length; i++)
        {
            // if there is any that have not been activated, do not initiate the end game sequence yet.
            if (activated[i] == true) {
                remaining--;
            }
            if (remaining == 0) {
                complete = true;
            }
                
        }

        // at this point the method has checked the list for any levers that remain to be activated. If there are any, complete will be false at this point.
        Debug.Log("Remaining levers " + remaining);

        if (complete == true)
        {
            Debug.Log("Conditional has been met");
            // end the game>
            Invoke("AirlockUnlock", airlockdelaytime);

        }

        if (doorsOpen)
        {
            Vector3 newGrav = new Vector3(1000, 0, 0);
            playerRB.AddForce(newGrav);
        }
    }

    public bool GetComplete() {
        return complete;
    }

    private void AirlockUnlock() {
        for (int i = 0; i < airlockDoors.Length; i++) {
            Destroy(airlockDoors[i]);
        }
        playerRB.useGravity = false;

        doorsOpen = true;
    }

    public void EndUI() {
        endUI.SetActive(true);
        pauseUI.SetActive(false);
    }
}

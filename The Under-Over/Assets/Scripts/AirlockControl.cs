using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirlockControl : MonoBehaviour
{

    bool[] activated;
    public Animator[] animators; // endgame level animators, use get bool
    public float airlockdelaytime;
    private void Awake()
    {
        activated = new bool[animators.Length]; // the animator of each lever, needed to activate the conditional
    }
    public void UpdateConditional(int seq, bool activeState)
    {
        activated[seq] = activeState;
        // now check to see if enabling / disabling this lever got us anywhere...
        bool complete = true;
        int remaining = animators.Length;
        for (int i = 0; i < animators.Length; i++)
        {
            // if there is any that have not been activated, do not initiate the end game sequence yet.
            if (activated[seq] == false)
                complete = false;
            else
                remaining--;
        }

        // at this point the method has checked the list for any levers that remain to be activated. If there are any, complete will be false at this point.
        Debug.Log("Remaining levers " + remaining);

        if (complete == true)
        {
            Debug.Log("Conditional has been met");
            // end the game
            Invoke("AvengersEndgame", 0f);
            Invoke("ArilockUnlock", airlockdelaytime);

        }
    }
}

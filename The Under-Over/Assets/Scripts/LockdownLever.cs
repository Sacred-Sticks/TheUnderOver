using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockdownLever : MonoBehaviour
{
    Animator leverAnim;
    [SerializeField] bool isActive;
    AirlockControl controller;
    public int seq;
    // Start is called before the first frame update
    private void Awake()
    {
        controller = GameObject.Find("SystemAI").GetComponent<AirlockControl>();
        GetComponent<Animator>();
    }
    void Interact()
    {
        isActive = !isActive;
        leverAnim.SetBool("isActive", isActive);
        controller.UpdateConditional(seq, isActive);
    }

    // no actual target that we are enabling / disabling with this script so this is all we need.
}

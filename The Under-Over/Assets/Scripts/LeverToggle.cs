using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverToggle : MonoBehaviour
{
    [SerializeField] GameObject[] target;
    [SerializeField] Animator[] optional_doorAnim;
    Animator leverAnim;
    [SerializeField] bool isActive;
    // Update is called once per frame
    public void Awake()
    {
        leverAnim = GetComponent<Animator>();
        leverAnim.SetBool("isActive", isActive);
        changeActiveState();
    }

    public void Interact()
    {
        //Debug.Log("Somebody pull me!");
        isActive = !isActive;
        leverAnim.SetBool("isActive", isActive);

        if (optional_doorAnim != null)
            changeAnimState();

        changeActiveState();
    }

    private void changeActiveState() {
        for (int i = 0; i < target.Length; i++)
            if (target[i] != null)
            target[i].SetActive(isActive);
            //Debug.Log("Activity Changed");
    }

    private void changeAnimState() {
        for (int i = 0; i < optional_doorAnim.Length; i++)
            if (optional_doorAnim[i] != null)
            optional_doorAnim[i].SetBool("isOpen", !isActive);
    }

    public bool GetIsActive() {
        return isActive;
    }
}

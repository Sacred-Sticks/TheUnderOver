using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverToggle : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Animator optional_doorAnim;
    Animator leverAnim;
    bool isActive;
    // Update is called once per frame
    public void Awake()
    {
        leverAnim = GetComponent<Animator>();
        isActive = false;
        leverAnim.SetBool("isActive", isActive);
        target.SetActive(isActive);
    }

    public void Interact()
    {
        //Debug.Log("Somebody pull me!");
        isActive = !isActive;
        leverAnim.SetBool("isActive", isActive);

        if (optional_doorAnim)
            optional_doorAnim.SetBool("isOpen", isActive);

        target.SetActive(isActive);
    }
}

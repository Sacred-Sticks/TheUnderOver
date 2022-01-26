using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScannerControl : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerControl;
    [SerializeField] private GameObject monster;
    [SerializeField] private GameObject redCam;
    [SerializeField] private float timeForScan;
    [SerializeField] private GameObject screen;
    private InputAction scannerAction;
    private Animator animator;

    private float scannerValue;
    private float scanTimer;
    private bool scanning;

    private void Awake() {
        var actionMap = playerControl.FindActionMap("Main Controls");
        scannerAction = actionMap.FindAction("Scan");

        scannerAction.performed += OnScanUpdate;
        scannerAction.canceled += OnScanUpdate;
        scannerAction.Enable();

        animator = GetComponent<Animator>();
    }

    private void OnScanUpdate(InputAction.CallbackContext context) {
        scannerValue = context.ReadValue<float>();
        scanTimer = 0;
    }

    private void Update() {
        if (scannerValue == 0) {
            animator.SetBool("Scanning", false);
            //this.gameObject.SetActive(false);
        } else {
            animator.SetBool("Scanning", true);
            GetComponentInParent<StartLevel>().setTime(1);
        }

        if (scannerValue > 0 && scanTimer == 0)
        {
            scanning = true;
            Debug.Log("Now Scanning");
        }

        if (scanning)
        {
            scanTimer += Time.deltaTime;
            redCam.SetActive(true);

            if (scanTimer > timeForScan)
            {
                scanning = false;
                scanTimer = 0;
                Debug.Log("Scanning Over");
            }
        }
        else
        {
            redCam.SetActive(false);
        }
    }
}

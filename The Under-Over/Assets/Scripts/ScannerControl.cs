using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScannerControl : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerControl;

    private InputAction scannerAction;
    private Animator animator;

    private float scannerValue;

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
    }

    private void Update() {
        if (scannerValue == 0) {
            animator.SetBool("Scanning", false);
        } else {
            animator.SetBool("Scanning", true);
        }
    }
}

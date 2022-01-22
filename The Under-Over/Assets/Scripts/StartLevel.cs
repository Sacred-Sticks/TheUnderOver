using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StartLevel : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerControls;
    private InputAction scanAction;
    private float scanValue;

    private void Awake() {
        var actionMap = playerControls.FindActionMap("Main Controls");
        scanAction = actionMap.FindAction("Scan");

        scanAction.performed += OnScanChange;
        scanAction.canceled += OnScanChange;
        scanAction.Enable();
    }

    private void OnScanChange(InputAction.CallbackContext context) {
        scanValue = context.ReadValue<float>();
    }

    private void Start() {
        Time.timeScale = 0.0f;
    }

    private void Update() {
        if (scanValue != 0) {
            Time.timeScale = 1.0f;
        }
    }
}

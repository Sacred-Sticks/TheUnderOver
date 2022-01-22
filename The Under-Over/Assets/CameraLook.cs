using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerControls;
    [SerializeField] private Transform playerBody;
    [SerializeField] private float mouseSensitivity;

    private InputAction lookAction;
    private float horz;
    private float vert;
    private float verticalRotation;

    private void Awake() {
        var actionMap = playerControls.FindActionMap("Main Controls");
        lookAction = actionMap.FindAction("Look");

        lookAction.performed += OnLookChange;
        lookAction.canceled += OnLookChange;
        lookAction.Enable();

        verticalRotation = 0;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        UpdateHorz();
        UpdateVert();
    }
    private void OnLookChange(InputAction.CallbackContext context) {
        Vector2 cameraLook = context.ReadValue<Vector2>();

        horz = cameraLook.x * mouseSensitivity * Time.deltaTime;
        vert = cameraLook.y * mouseSensitivity * Time.deltaTime;
    }

    private void UpdateHorz() {
        playerBody.Rotate(Vector3.up, horz);
    }

    private void UpdateVert() {
        verticalRotation -= vert;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}

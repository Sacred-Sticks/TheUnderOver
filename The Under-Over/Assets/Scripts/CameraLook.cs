using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerControls;
    [SerializeField] private Transform playerBody;
    [SerializeField] private float maxSensitivity;

    private InputAction lookAction;
    private float horz;
    private float vert;
    private float verticalRotation;
    private float currentSensitivity;

    private void Awake() {
        var actionMap = playerControls.FindActionMap("Main Controls");
        lookAction = actionMap.FindAction("Look");

        lookAction.performed += OnLookChange;
        lookAction.canceled += OnLookChange;
        lookAction.Enable();

        verticalRotation = 0;

        Cursor.lockState = CursorLockMode.Locked;
    }



    private void LateUpdate() {
        UpdateHorz();
        UpdateVert();
    }
    private void OnLookChange(InputAction.CallbackContext context) {
        Vector2 cameraLook = context.ReadValue<Vector2>();

        horz = cameraLook.x * currentSensitivity;
        vert = cameraLook.y * currentSensitivity;
    }

    private void UpdateHorz() {
        playerBody.Rotate(Vector3.up, horz);
    }

    private void UpdateVert() {
        verticalRotation -= vert;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    public float getMaxSensitivity() {
        return maxSensitivity;
    }

    public void setMouseSensitivity(float sensitivity) {
        currentSensitivity = sensitivity;
        Debug.Log(currentSensitivity);
    }
}

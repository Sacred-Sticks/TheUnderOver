using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ending : MonoBehaviour
{
    public InputActionAsset playerControls;
    public GameObject endMenu;
    private InputAction pauseOpened;

    private void Awake()
    {
        endMenu.SetActive(false);

        var actionMap = playerControls.FindActionMap("Main Controls");
        pauseOpened = actionMap.FindAction("Pause");

        pauseOpened.performed += OnChangePause;
        pauseOpened.Enable();
    }

    private void OnChangePause(InputAction.CallbackContext context)
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if (Cursor.lockState == CursorLockMode.None)
        {
            endMenu.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}

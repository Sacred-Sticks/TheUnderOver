using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerControls;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject player;
    private InputAction pauseOpened;
    bool paused;

    private void Awake() {
        pauseMenu.SetActive(false);

        var actionMap = playerControls.FindActionMap("Main Controls");
        pauseOpened = actionMap.FindAction("Pause");

        pauseOpened.performed += OnChangePause;
        pauseOpened.Enable();

        paused = false;

        cam.GetComponent<CameraLook>().setMouseSensitivity(cam.GetComponent<CameraLook>().getMaxSensitivity() * 0.5f);
    }

    private void OnChangePause(InputAction.CallbackContext context) {
        paused = !paused;
    }

    [SerializeField] private Camera cam;

    public void onClickResume() {
        paused = false;
    }

    public void onChangeSensitivity(float sensitivityBar) {
        float maxSensitivity = cam.GetComponent<CameraLook>().getMaxSensitivity();
        if (sensitivityBar < 0.5f)
        {
            sensitivityBar += 0.5f;
        } else if (sensitivityBar >0.5f)
        {
            sensitivityBar -= 0.5f;
        }
        float newSensitivity = maxSensitivity * (sensitivityBar);
        newSensitivity *= 0.5f;
        cam.GetComponent<CameraLook>().setMouseSensitivity(newSensitivity);
    }

    public void onClickMenu() {
        SceneManager.LoadScene("Main Menu");
    }

    private void Update() {
        if (paused) {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        } else {
            pauseMenu.SetActive(false);
            Time.timeScale = player.GetComponent<StartLevel>().getTime();
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}

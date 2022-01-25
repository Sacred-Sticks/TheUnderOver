using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] menuItems;
    [SerializeField] private GameObject[] creditsItems;
    [SerializeField] private GameObject[] controlsItems;
    
    private void Awake() {
        disableMenu(creditsItems);
        disableMenu(controlsItems);
        enableMenu(menuItems);
    }

    public void startButton() {
        SceneManager.LoadScene("Level");
    }

    public void creditsButton() {
        disableMenu(menuItems);
        disableMenu(controlsItems);
        enableMenu(creditsItems);
    }

    public void menuButton() {
        disableMenu(creditsItems);
        disableMenu(controlsItems);
        enableMenu(menuItems);
    }

    public void quitButton() {
        Application.Quit();
    }

    public void controlsButton() {
        disableMenu(menuItems);
        disableMenu(creditsItems);
        enableMenu(controlsItems);
    }

    private void disableMenu(GameObject[] menu) {
        for (int i = 0; i < menu.Length; i++) {
            menu[i].SetActive(false);
        }
    }

    private void enableMenu(GameObject[] menu) {
        for (int i = 0; i < menu.Length; i++) {
            menu[i].SetActive(true);
        }
    }
}

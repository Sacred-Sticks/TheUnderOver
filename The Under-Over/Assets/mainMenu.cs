using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] menuItems;
    [SerializeField] private GameObject[] creditsItems;
    
    private void Awake() {
        disableMenu(creditsItems);
        enableMenu(menuItems);
    }

    public void startButton() {
        SceneManager.LoadScene("Level");
    }

    public void creditsButton() {
        disableMenu(menuItems);
        enableMenu(creditsItems);
    }

    public void menuButton() {
        disableMenu(creditsItems);
        enableMenu(menuItems);
    }

    public void quitButton() {
        Application.Quit();
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

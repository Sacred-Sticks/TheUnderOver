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
    [SerializeField] private GameObject[] storyItems;
    
    private void Awake() {
        disableMenu(creditsItems);
        disableMenu(controlsItems);
        disableMenu(storyItems);
        enableMenu(menuItems);
    }

    public void startButton() {
        SceneManager.LoadScene("Level");
    }

    public void creditsButton() {
        disableMenu(menuItems);
        enableMenu(creditsItems);
    }
    public void controlsButton()
    {
        disableMenu(menuItems);
        enableMenu(controlsItems);
    }

    public void storyButton()
    {
        disableMenu(menuItems);
        enableMenu(storyItems); 
    }

    public void menuButton() {
        disableMenu(creditsItems);
        disableMenu(controlsItems);
        disableMenu(storyItems);
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

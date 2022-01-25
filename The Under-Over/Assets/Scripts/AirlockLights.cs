using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirlockLights : MonoBehaviour
{
    [SerializeField] private GameObject[] airlockSwitch;
    [SerializeField] private Light[] light;
    [SerializeField] private float waitTime;
    private bool active;

    [SerializeField] private Color[] colors;
    private Color currentColor;

    private int colorCounter;

    private void Awake() {
        active = false;
        currentColor = colors[0];
        colorCounter = 0;
    }

    private void Update()
    {
        if (!active) {
            active = GetComponent<AirlockControl>().GetComplete();
        } else {
            for (int i = 0; i < light.Length; i++) {
                light[i].color = currentColor;
            }
            colorCounter++;
            if (colorCounter % waitTime == 0)
                swapColors();
        }
    }

    private bool GetActive() {
        for (int i = 0; i < airlockSwitch.Length; i++) {
            bool isActive = airlockSwitch[i].GetComponent<AirlockLever>().isActive;
            if (!isActive) {
                return false;
            }
        }
        return true;
    }

    private void swapColors() {
        if (currentColor == colors[0]) {
            currentColor = colors[1];
        } else {
            currentColor = colors[0];
        }
    }
}

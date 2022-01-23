using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirlockLights : MonoBehaviour
{
    [SerializeField] private GameObject[] airlockSwitch;
    [SerializeField] private Light[] light;
    private bool active;

    private Color[] colors;
    private Color currentColor;

    private void Awake() {
        active = false;
        currentColor = colors[0];
    }

    private void Update()
    {
        if (!active) {
            active = GetActive();
        } else {
            for (int i = 0; i < light.Length; i++) {
                light[i].color = currentColor;
            }
            swapColors();
        }
    }

    private bool GetActive() {
        for (int i = 0; i < airlockSwitch.Length; i++) {
            bool isActive = airlockSwitch[i].GetComponent<LeverToggle>().GetIsActive();
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

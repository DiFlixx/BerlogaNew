using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureUI : MonoBehaviour
{
    [SerializeField]
    private TemperatureManager temperatureManager;

    [SerializeField]
    private GameObject[] temperatureSprites;

    public void UpdateTemperatureUI()
    {
        int temperature = temperatureManager.GetTemperature();

        int temperatureType = Mathf.Clamp(temperature/10, 0, temperatureSprites.Length - 1);

        if (temperatureType != temperatureSprites.Length - 1)
        {
            temperatureSprites[temperatureType+1].SetActive(false);
        }
        temperatureSprites[temperatureType].SetActive(true);
    }

    void Start()
    {
        UpdateTemperatureUI();
    }
}

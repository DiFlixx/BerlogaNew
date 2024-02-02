using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    private HealthManager _healthManager;
    private HungerSystem _hungerSystem;
    private TemperatureManager _temperatureManager;

    void Start()
    {
        Load();
    }

    void Load()
    {
        player1.transform.position = new Vector3(PlayerPrefs.GetFloat("Player1_x"), PlayerPrefs.GetFloat("Player1_y"));
        player2.transform.position = new Vector3(PlayerPrefs.GetFloat("Player2_x"), PlayerPrefs.GetFloat("Player2_y"));
        _hungerSystem.currentHunger = PlayerPrefs.GetInt("saveHunger");
        _temperatureManager.currentTemperature = PlayerPrefs.GetInt("saveTemperature");
    }
}

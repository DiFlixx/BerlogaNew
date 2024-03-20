using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureManager : MonoBehaviour
{
    public int maxTemperature = 79;
    public int currentTemperature;
    public int temperatureDecayRate = 1;
    [SerializeField]
    private HealthManager _healthManager;

    [SerializeField]
    private TemperatureUI _temperatureUI;

    private int _currentDecay;

    void Start()
    {
        _currentDecay = temperatureDecayRate;
        currentTemperature = maxTemperature;
        InvokeRepeating("DecayTemperature", 1f, 1f);
    }

    public void Pause()
    {
        _currentDecay = 0;
    }

    public void UnPause()
    {
        _currentDecay = temperatureDecayRate;
    }

    void DecayTemperature()
    {
        currentTemperature -= _currentDecay; ;
        currentTemperature = Mathf.Clamp(currentTemperature, 0, maxTemperature);
        _temperatureUI.UpdateTemperatureUI();
        if (currentTemperature <= 9)
        {
            _healthManager.TakeDamage(1);
        }
    }

    public int GetTemperature()
    {
        return currentTemperature;
    }

}

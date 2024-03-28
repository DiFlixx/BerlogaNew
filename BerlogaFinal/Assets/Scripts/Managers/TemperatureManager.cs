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
        InvokeRepeating("DecayTemperature", 4f, 4f);
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
        if (currentTemperature <= 9)
        {
            _healthManager.TakeDamage(1);
            return;
        }

        currentTemperature -= _currentDecay; ;
        currentTemperature = Mathf.Clamp(currentTemperature, 0, maxTemperature);
        _temperatureUI.UpdateTemperatureUI();
    }

    public int GetTemperature()
    {
        return currentTemperature;
    }

}

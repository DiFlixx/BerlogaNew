using UnityEngine;

public class HungerSystem : MonoBehaviour
{
    public int maxHunger = 7;
    public int currentHunger;

    [SerializeField]
    private int hungerDecayRate = 1;
    [SerializeField]
    private HungerUI _hungerUI;
    [SerializeField]
    private HealthManager _healthManager;

    private int _currentDecay;

    void Start()
    {
        _currentDecay = hungerDecayRate;
        currentHunger = maxHunger;
        InvokeRepeating("DecayHunger", 25f, 25f);
    }

    public void Pause()
    {
        _currentDecay = 0;
    }

    public void UnPause()
    {
        _currentDecay = hungerDecayRate;
    }

    void DecayHunger()
    {
        if (currentHunger <= 0)
        {
            _healthManager.TakeDamage(1);
            return;
        }

        currentHunger -= _currentDecay;
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);
        _hungerUI.UpdateHungerUI();
    }

    public void Eat(int amount)
    {
        currentHunger += amount;
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);
        _hungerUI.UpdateHungerUI();
    }

    public int GetHunger()
    {
        return currentHunger;
    }
}


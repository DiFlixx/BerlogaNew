using UnityEngine;
using UnityEngine.UI;

public class HungerUI : MonoBehaviour
{
    [SerializeField]
    private HungerSystem hungerManager;

    [SerializeField]
    private GameObject[] hungerIcons;

    public void UpdateHungerUI()
    {
        int hunger = hungerManager.GetHunger();

        if (hunger != hungerIcons.Length - 1)
        {
            hungerIcons[hunger + 1].SetActive(false);
        }
        hungerIcons[hunger].SetActive(true);
    }

    void Start()
    {
        UpdateHungerUI();
    }
}
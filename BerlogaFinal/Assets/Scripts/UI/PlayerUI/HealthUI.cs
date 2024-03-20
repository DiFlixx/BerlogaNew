using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private HealthManager healthManager;

    [SerializeField]
    private GameObject[] hearts;

    public void UpdateHealthUI()
    {
        int health = healthManager.GetHealth();


        if (health != hearts.Length - 1)
        {
            hearts[health + 1].SetActive(false);
        }
        hearts[health].SetActive(true);
    }

    void Start()
    {
        UpdateHealthUI();
    }
}
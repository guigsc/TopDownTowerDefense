using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider _healthBar;

    void Start()
    {
        _healthBar = GetComponent<Slider>();
    }

    public void SetMaxHealth(int maxHealth) 
    {
        _healthBar.maxValue = maxHealth;
    }

    public void SetHealth(int healthPoints)
    {
        _healthBar.value = healthPoints;
    }
}

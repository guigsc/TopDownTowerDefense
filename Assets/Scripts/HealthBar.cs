using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;

    public void SetMaxHealth(int maxHealth) 
    {
        _healthBar.maxValue = maxHealth;
    }

    public void SetHealth(int healthPoints)
    {
        _healthBar.value = healthPoints;
    }
}

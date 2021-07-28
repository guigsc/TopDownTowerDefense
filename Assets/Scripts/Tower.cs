using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    public int MaxHealth => _maxHealth;

    private int _health;
    
    private static Tower _instance;
    public static Tower Instance => _instance;

    private HealthBar _healthBar;
    
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this);
            return;
        }

        _instance = this;
    }

    private void Start()
    {
        _health = _maxHealth;
        
        _healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        _healthBar.SetMaxHealth(_maxHealth);
        _healthBar.SetHealth(_health);
    }

    public void DealDamage(int damage)
    {
        _health -= damage;

        _healthBar.SetHealth(_health);

        if (_health <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}

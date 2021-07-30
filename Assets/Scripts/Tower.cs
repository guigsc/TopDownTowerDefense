using UnityEngine;

public class Tower : Target
{
    [SerializeField] private int _maxHealth = 100;
    public int MaxHealth => _maxHealth;

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

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        _healthBar.SetHealth(_health);
    }

    protected override void Die()
    {
        GameManager.Instance.GameOver();
    }
}

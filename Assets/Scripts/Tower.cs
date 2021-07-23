using UnityEngine;

public class Tower : MonoBehaviour
{
    private static Tower _instance;
    public static Tower Instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this);
            return;
        }

        _instance = this;
    }

    [SerializeField] int health = 100;

    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}

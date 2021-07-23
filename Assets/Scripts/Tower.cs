using UnityEngine;

public class Tower : MonoBehaviour
{
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

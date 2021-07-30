using UnityEngine;

public abstract class Target : MonoBehaviour
{
    [SerializeField] protected int _health;

    public virtual void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
    }

    protected abstract void Die();
}

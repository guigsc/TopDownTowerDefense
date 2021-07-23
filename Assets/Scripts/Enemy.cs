using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] private float speed = 2f;
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private int health = 10;

    private Rigidbody _rigidbody;

    private float attackDistance = 2.5f;
    private float attackRate = 1f;
    private float nextAttack = 0;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float distanceFromTower = Vector3.Distance(transform.position, Tower.Instance.transform.position);

        Vector3 towerDirection = Tower.Instance.transform.position - transform.position;
        RotateTowards(towerDirection);

        if (distanceFromTower > attackDistance)
            MoveTowards(towerDirection);
        else
            Attack();
    }

    private void Attack()
    {
        if (Time.time > nextAttack)
        {
            nextAttack = Time.time + attackRate;
            Tower.Instance.DealDamage(attackDamage);
        }
    }

    private void RotateTowards(Vector3 direction)
    {
        var lookAtRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        _rigidbody.MoveRotation(lookAtRotation); 
    }

    private void MoveTowards(Vector3 direction)
    {
        _rigidbody.MovePosition(_rigidbody.position + direction.normalized * speed * Time.fixedDeltaTime);
    }

    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

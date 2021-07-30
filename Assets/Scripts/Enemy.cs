using UnityEngine;

public abstract class Enemy : Target
{
    
    [SerializeField] protected float _speed = 2f;
    [SerializeField] protected int _attackDamage = 10;
    [SerializeField] protected float _attackDistance = 2.5f;
    [SerializeField] protected float _attackRate = 1f;

    private float _nextAttack = 0;

    protected Rigidbody _rigidbody;

    protected virtual void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float distanceFromTower = Vector3.Distance(transform.position, Tower.Instance.transform.position);

        Vector3 towerDirection = Tower.Instance.transform.position - transform.position;
        RotateTowards(towerDirection);

        if (distanceFromTower > _attackDistance)
            MoveTowards(towerDirection);
        else
            StartAttacking();
    }

    private void StartAttacking()
    {
        if (Time.time > _nextAttack)
        {
            _nextAttack = Time.time + _attackRate;
            Attack();
        }
    }

    private void RotateTowards(Vector3 direction)
    {
        var lookAtRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        _rigidbody.MoveRotation(lookAtRotation); 
    }

    private void MoveTowards(Vector3 direction)
    {
        _rigidbody.MovePosition(_rigidbody.position + direction.normalized * _speed * Time.fixedDeltaTime);
    }
    
    protected abstract void Attack();

    protected override void Die()
    {
        Destroy(gameObject);
    }
}

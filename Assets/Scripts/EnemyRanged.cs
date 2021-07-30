using System;
using UnityEngine;

public class EnemyRanged : Enemy
{
    [SerializeField] private GameObject _fireballPrefab;
    
    private Transform _fireballSpawnObject;

    protected override void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _fireballSpawnObject = transform.Find("FireballSpawn");
    }

    protected override void Attack()
    {
        FireProjectile();
    }

    private void FireProjectile()
    {
        var fireballGO = Instantiate(_fireballPrefab, _fireballSpawnObject.position, transform.rotation);
        fireballGO.GetComponent<Projectile>().onHit += OnFireballHit;
    }

    private void OnFireballHit(Target target)
    {
        var tower = target as Tower;
        if (tower != null)
        {
            tower.TakeDamage(_attackDamage);
        }
    }
}

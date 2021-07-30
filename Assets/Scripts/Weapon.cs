using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private int _bulletDamage;

    private Transform _bulletSpawnObject;

    private InputHandler _inputHandler;
    
    private void Start()
    {
        _inputHandler = GetComponent<InputHandler>();
        _bulletSpawnObject = transform.Find("Weapon");
    }

    private void Update()
    {
        if(_inputHandler.HasPressedFire1)
        {
            Fire();
        }
    }

    private void Fire()
    {
        var bulletGO = Instantiate(_bulletPrefab, _bulletSpawnObject.position, transform.rotation);
        bulletGO.GetComponent<Projectile>().onHit += OnBulletHit;
    }

    void OnBulletHit(Target target)
    {
        var enemy = target as Enemy;
        if (enemy != null)
        {
            enemy.TakeDamage(_bulletDamage);
        }
    }
}

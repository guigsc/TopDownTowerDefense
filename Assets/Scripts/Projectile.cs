using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;
    [SerializeField] private TargetEnum _target;

    public event Action<Target> onHit;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + transform.forward * _speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        var target = other.GetComponent<Target>();
        if (target != null && target.CompareTag(_target.ToString()))
        {
            Hit(target);
        }

        Destroy(gameObject);
    }

    public void Hit(Target target)
    {
        if (onHit != null) onHit.Invoke(target);
    }
}

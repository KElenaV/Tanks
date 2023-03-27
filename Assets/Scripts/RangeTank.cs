using System;
using UnityEngine;

public class RangeTank : ShootableTank
{
    [SerializeField] private float _shootDistance = 5f;

    private float _elapsedTime;
    private Transform _target;

    protected override void Start()
    {
        base.Start();
        _target = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        Rigidbody2D.velocity = Vector2.zero;

        if (_target)
        {
            if(Vector2.Distance(transform.position, _target.position) > _shootDistance)
                Move();
        
            SetAngle(_target.position);
        
            Shoot();
        }
    }

    protected override void Move()
    {
        transform.Translate(Vector2.down * (MovementSpeed * Time.deltaTime));
    }

    private void Shoot()
    {
        if (_elapsedTime < ReloadTime)
            _elapsedTime += Time.deltaTime;
        else
        {
            ShootOneBullet();
            _elapsedTime = 0;
        }
    }
}

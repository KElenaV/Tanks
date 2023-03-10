using System;
using UnityEngine;

public class MeleeTank : Tank
{
    [SerializeField] private int _damage = 5;
    
    private Transform _target; //todo: check can i change Transform to Player
    private float _timer;
    private float _hitCooldown = 1f;

    protected override void Start()
    {
        base.Start();
        _target = FindObjectOfType<Player>().transform; //todo: Init method in Spawner
    }

    private void Update()
    {
        Move();
        
        SetAngle(_target.position);
    }

    protected override void Move()
    {
        Rigidbody2D.velocity = Vector2.zero;
        transform.Translate(Vector2.down * (MovementSpeed * Time.deltaTime));
    }
}

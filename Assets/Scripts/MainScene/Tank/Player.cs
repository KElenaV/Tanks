using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : ShootableTank
{
    public static Player Instance;
    
    [SerializeField] private List<Gun> _guns;
    
    private float _elapsedTime;
    private Camera _camera;

    private void Awake()
    {
        Instance = this;
    }

    protected override void Start()
    {
        base.Start();
        _camera = Camera.main;
    }

    private void Update()
    {
        Move();

        SetAngle(_camera.ScreenToWorldPoint(Input.mousePosition));
        
        Shoot();
    }

    protected override void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector2 direction = new Vector2(horizontal, vertical);
        Rigidbody2D.velocity = direction.normalized * MovementSpeed;
    }

    public override void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        UI.UpdateHp(CurrentHealth);

        if (CurrentHealth <= 0)
        {
            Stats.ResetAllStats();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Shoot()
    {
        if (_elapsedTime < ReloadTime)
            _elapsedTime += Time.deltaTime;
        else
        {
            if (Input.GetMouseButton(0))
            {
                ShootOneBullet();
                _elapsedTime = 0;
            }
        }
    }
}

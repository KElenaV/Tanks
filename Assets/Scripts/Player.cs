using UnityEngine;

public class Player : ShootableTank
{
    private float _elapsedTime;
    private Camera _camera;

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

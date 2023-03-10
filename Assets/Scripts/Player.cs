using UnityEngine;

public class Player : ShootableTank
{
    private float _elapsedTime;
    
    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= ReloadTime)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
                _elapsedTime = 0;
            }
        }
        
        Move();
        
        SetAngle(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    protected override void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector2 direction = new Vector2(horizontal, vertical);
        Rigidbody2D.velocity = direction.normalized * MovementSpeed;
    }
}

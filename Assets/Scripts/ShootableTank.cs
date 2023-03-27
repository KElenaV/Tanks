using UnityEngine;

public abstract class ShootableTank : Tank
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;
    
    [SerializeField] protected float ReloadTime = 0.5f;

    protected void ShootOneBullet()
    {
        Instantiate(_bullet, _shootPoint.position, transform.rotation);
    }
}

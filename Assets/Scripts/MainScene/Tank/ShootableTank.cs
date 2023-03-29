using UnityEngine;

public abstract class ShootableTank : Tank
{
    [SerializeField] private string _bulletTag;
    [SerializeField] private Transform _shootPoint;
    
    [SerializeField] protected float ReloadTime = 0.5f;

    private ObjectPooler _objectPooler;

    protected override void Start()
    {
        base.Start();
        _objectPooler = ObjectPooler.Instance;
    }

    protected void ShootOneBullet()
    {
        _objectPooler.SpawnFromPool(_bulletTag, _shootPoint.position, transform.rotation);
    }
}

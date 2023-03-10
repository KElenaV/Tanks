using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Tank : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 30;
    
    [SerializeField] protected float MovementSpeed = 3f;
    [SerializeField] protected float RotationSpeed = 30f;

    protected Rigidbody2D Rigidbody2D;
    
    private int _currentHealth;
    private float _angleOffset = 90;

    protected virtual void Start()
    {
        _currentHealth = _maxHealth;
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if(_currentHealth <= 0)
            Destroy(gameObject);
    }

    protected void SetAngle(Vector3 target)
    {
        Vector3 deltaPosition = target - transform.position;
        float angleZ = Mathf.Atan2(deltaPosition.y, deltaPosition.x) * Mathf.Rad2Deg;
        Quaternion angle = Quaternion.Euler(0,0,angleZ + _angleOffset);
        transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * RotationSpeed);
    }

    protected abstract void Move();
}

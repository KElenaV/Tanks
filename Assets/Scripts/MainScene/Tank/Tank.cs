using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Tank : MonoBehaviour
{
    [SerializeField] protected float MovementSpeed = 3f;
    [SerializeField] protected float RotationSpeed = 30f;
    
    [SerializeField] private int _maxHealth = 30;
    [SerializeField] private int _points = 0;
    [SerializeField] private string _tag;

    protected Rigidbody2D Rigidbody2D;
    protected int CurrentHealth;
    protected UI UI;

    private float _angleOffset = 90;

    public string TankTag => _tag;

    protected virtual void Start()
    {
        CurrentHealth = _maxHealth;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        UI = FindObjectOfType<UI>().GetComponent<UI>();
    }

    public virtual void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        
        if (CurrentHealth <= 0)
        {
            Stats.Score += _points;
            UI.UpdateScoreAndLevel();
            gameObject.SetActive(false);
        }
    }

    protected void SetAngle(Vector3 target)
    {
        Vector3 deltaPosition = target - transform.position;
        float angleZ = Mathf.Atan2(deltaPosition.y, deltaPosition.x) * Mathf.Rad2Deg;
        Quaternion angle = Quaternion.Euler(0,0,angleZ + _angleOffset);
        transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * RotationSpeed);
    }

    protected virtual void Move()
    {
        Rigidbody2D.velocity = Vector2.zero;
        transform.Translate(Vector2.down * (MovementSpeed * Time.deltaTime));
    }
}

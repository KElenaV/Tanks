using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private string _myTag = "default";

    private void Update()
    {
        transform.Translate(Vector2.down * (_speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Tank tank) && !other.gameObject.CompareTag(_myTag))
        {
            tank.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}

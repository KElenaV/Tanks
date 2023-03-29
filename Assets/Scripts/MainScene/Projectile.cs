using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // [SerializeField] private int _damage = 1;
    // [SerializeField] private float _speed = 1f;
    // [SerializeField] private string _myTag = "default";
    [SerializeField] private Bullet _bullet;

    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(4);
    }

    private void OnEnable()
    {
        StartCoroutine(Deactivate());
    }

    private void Update()
    {
        transform.Translate(Vector2.down * (_bullet.Speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Tank tank) && !other.gameObject.CompareTag(_bullet.MyTag))
        {
            tank.TakeDamage(_bullet.Damage);
            gameObject.SetActive(false);
        }
    }

    private IEnumerator Deactivate()
    {
        if (gameObject.activeSelf)
        {
            yield return _waitForSeconds;
            gameObject.SetActive(false);
        }
    }
}

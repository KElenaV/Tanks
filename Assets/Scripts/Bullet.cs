using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _speed = 1f;

    private void Update()
    {
        transform.Translate(Vector2.down * (_speed * Time.deltaTime));
    }
}

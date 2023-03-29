using UnityEngine;

public class MeleeTank : Tank
{
    [SerializeField] private int _damage = 5;
    
    private Transform _target; //todo: check can i change Transform to Player
    private float _timer;
    private float _hitCooldown = 1f;

    protected override void Start()
    {
        base.Start();
        //_target = FindObjectOfType<Player>().transform; //todo: Init method in Spawner
        _target = Player.Instance.transform;
    }

    private void Update()
    {
        Rigidbody2D.velocity = Vector2.zero;

        if (_target)
        {
            if (_timer <= 0)
            {
                Move();
        
                SetAngle(_target.position);
            }
            else
            {
                _timer -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player) && _timer <= 0)
        {
            player.TakeDamage(_damage);
            _timer = _hitCooldown;
        }
    }
}

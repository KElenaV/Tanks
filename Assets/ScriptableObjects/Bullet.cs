using UnityEngine;

[CreateAssetMenu(menuName = "Projectiles/Bullet")]
public class Bullet : ScriptableObject
{
    public int Damage;
    public int Speed;
    public string MyTag;
}

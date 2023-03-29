using UnityEngine;

[CreateAssetMenu(fileName = "New Barrel", menuName = "Items/Barrel")]
public class Barrel : ScriptableObject
{
    public string Title;
    public string Description;
    public Sprite Sprite;
    public int Radius;
}

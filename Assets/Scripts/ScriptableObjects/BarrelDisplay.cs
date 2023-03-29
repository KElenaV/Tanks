using UnityEngine;
using UnityEngine.UI;

public class BarrelDisplay : MonoBehaviour
{
    [SerializeField] private Barrel _barrel;
    [SerializeField] private Text _title;
    [SerializeField] private Text _radius;
    [SerializeField] private Text _description;
    [SerializeField] private Image _image;

    private void Start()
    {
        _title.text = _barrel.Title;
        _radius.text = _barrel.Radius.ToString();
        _description.text = _barrel.Description;
        _image.sprite = _barrel.Sprite;
    }
}

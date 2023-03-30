using UnityEngine;

public class PersonSubscriber1 : MonoBehaviour
{
    [SerializeField] private Person _person;

    private void Start()
    {
        print("Подписчик 1");
        _person.OnDied += OnPersonOneDied;
        _person.OnDiedEvent += OnPersonOneDied;
    }

    private void OnPersonOneDied(string name, int age)
    {
        print($"{name} умер в возрасте {age}");
    }
}

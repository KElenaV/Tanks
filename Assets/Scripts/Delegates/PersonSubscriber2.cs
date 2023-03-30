using System;
using UnityEngine;

public class PersonSubscriber2 : MonoBehaviour
{
    [SerializeField] private Person _person;

    private void Start()
    {
        print("Подписчик 2");
        _person.OnDied += OnPersonTwoDied;
        _person.OnDiedEvent += OnPersonTwoDied;
    }

    private void OnPersonTwoDied(string name, int age)
    {
        print($"Его звали {name}...");
    }
}

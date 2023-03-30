using System;
using UnityEngine;

public class ComparisonDelegateAndEvent : MonoBehaviour
{
    [SerializeField] private Person _person;

    private void Start()
    {
        _person.OnDied("Dan", 60);
        _person.OnDied = null;
    }

    private void ShowInfo(string name, int age)
    {
        print(name);
        print(age);
    }
}

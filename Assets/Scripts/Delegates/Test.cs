using System;
using UnityEngine;

public class Test : MonoBehaviour
{
    private delegate void TestDelegate();

    private TestDelegate _testDelegate;
    private event TestDelegate _testEvent;
    private event TestDelegate TestEvent
    {
        add
        {
            _testEvent += value;
            print($"метод {value.Method.Name}() добавлен в событие.");
        }
        remove
        {
            _testEvent -= value;
            print($"метод {value.Method.Name}() удален из события.");
        }
    }

    private void Start()
    {
       
    }
}

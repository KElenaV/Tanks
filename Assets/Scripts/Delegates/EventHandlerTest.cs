using System;
using UnityEngine;

public class EventHandlerTest : MonoBehaviour
{
    private event EventHandler<CustomArgs> _testEvent;

    private void Start()
    {
        _testEvent += OnTestEvent;
        _testEvent?.Invoke(this, new CustomArgs());
    }

    private void OnTestEvent(object obj, CustomArgs args)
    {
        print($"{args.Id}: name {args.Name}");
    }
}


public class CustomArgs : EventArgs
{
    public int Id;
    public string Name;
}

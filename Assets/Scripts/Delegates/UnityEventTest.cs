using UnityEngine;
using UnityEngine.Events;

public class UnityEventTest : MonoBehaviour
{
    public UnityEvent<int, string> OnTestEvent;

    private void Start()
    {
        OnTestEvent.AddListener(OnTestEventAction);
        OnTestEvent.RemoveListener(OnTestEventAction);
        OnTestEvent.RemoveAllListeners();
    }

    private void OnTestEventAction(int id, string name)
    {
        print($"{id} - {name}");
    }
}

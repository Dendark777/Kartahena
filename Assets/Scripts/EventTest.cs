using UnityEngine;

public class EventTest : MonoBehaviour
{
    public delegate void SomeAction(int argument);
    public event SomeAction gameStartAction;
    void Start()
    {
        gameStartAction?.Invoke(0);
    }
}

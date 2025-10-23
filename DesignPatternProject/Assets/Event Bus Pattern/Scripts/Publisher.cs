using UnityEditor;
using UnityEngine;

public class Publisher : MonoBehaviour
{

    void Start()
    {
        EventManager.Publish(Condition.START);
    }

    void Pause()
    {
        EventManager.Publish(Condition.PAUSE);
    }
}

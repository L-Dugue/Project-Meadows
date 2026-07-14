using UnityEngine;
using UnityEngine.Events;
using Yarn.Unity;

public class PlayerSleep : MonoBehaviour
{
    public UnityEvent OnPlayerSleepEvent;

    [YarnCommand("Playersleep")]
    public void Sleep()
    {
        OnPlayerSleepEvent.Invoke();
    }
}

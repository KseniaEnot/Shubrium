using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class RespawnEventEmitter : MonoBehaviour
{
    public UnityEvent respawnEvent;

    public void Invoke()
    {
        respawnEvent.Invoke();
    }

    public void AddListener(UnityAction call)
    {
        respawnEvent.AddListener(call);
    }
}

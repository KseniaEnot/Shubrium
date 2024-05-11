using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawnable : MonoBehaviour
{
    public Transform respawnPoint;
    public RespawnEventEmitter[] respawnEventSources;

    private void Start()
    {
        foreach (var eventSource in respawnEventSources)
        {
            eventSource.AddListener(delegate { Respawn(); });
        }
    }

    public void Respawn()
    {
        gameObject.SetActive(true);
        transform.position = respawnPoint.position;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigItem : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Digging>().hasShovel = true;
            gameObject.SetActive(false);
            GetComponent<FMODUnity.StudioEventEmitter>().Play();

        }
    }
}

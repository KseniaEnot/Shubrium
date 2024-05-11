using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Digging : MonoBehaviour
{
    public Transform digStartPoint;
    public float diggingCheckSize;
    public string diggableTag;

    public UnityEvent digging;

    public bool hasShovel;

    // Start is called before the first frame update
    void Start()
    {
        hasShovel = false;
    }
    
    public void Dig()
    {
        Collider[] tracedTargets = Physics.OverlapSphere(digStartPoint.position, diggingCheckSize);
        foreach (Collider tracedTarget in tracedTargets)
        {
            if (tracedTarget.CompareTag(diggableTag))
            {
                tracedTarget.gameObject.SetActive(false);
                digging.Invoke();
                break;
            }
        }
    }
}

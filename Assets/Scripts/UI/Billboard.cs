using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cameraPosition;

    void LateUpdate()
    {
        transform.LookAt(transform.position + cameraPosition.forward);
    }
}

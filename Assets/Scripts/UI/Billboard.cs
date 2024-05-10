using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cameraPosition;
    private void Start()
    {
        cameraPosition = Camera.main.transform;
        GetComponent<Canvas>().worldCamera = Camera.main;
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + cameraPosition.forward);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public KeyCode flashlightControlKey;

    public GameObject flashlight;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(flashlightControlKey))
        {
            flashlight.SetActive(!flashlight.activeSelf);
        }

    }
}

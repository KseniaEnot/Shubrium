using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventHandler : MonoBehaviour
{
    public UnityEvent FootstepEvent;
    public UnityEvent JumpStartEvent;
    public UnityEvent JumpLandingEvent;


    public void CallFootstepEvent()
    {
        FootstepEvent.Invoke();
    }

    public void CallJumpStartEvent()
    {
        JumpStartEvent.Invoke();
    }

    public void CallJumpLandingEvent()
    {
        JumpLandingEvent.Invoke();
    }
}

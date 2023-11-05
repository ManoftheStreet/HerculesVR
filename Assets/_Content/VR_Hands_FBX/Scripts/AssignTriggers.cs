using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AssignTriggers : MonoBehaviour
{
    public XRBaseController controller;
    public ArcheryHandAnimation handAnimation;

    private void Start()
    {
        handAnimation = GetComponentInChildren<ArcheryHandAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(handAnimation == null)
            handAnimation = GetComponentInChildren<ArcheryHandAnimation>();
        if (handAnimation == null)
            return;
        if (controller.selectInteractionState.activatedThisFrame)
            handAnimation.TriggerGrab();
        else if (controller.selectInteractionState.deactivatedThisFrame)
            handAnimation.TriggerLet();
    }
}

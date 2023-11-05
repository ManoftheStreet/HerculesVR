using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcheryHandAnimation : MonoBehaviour {

    private Animator animator;

	void Start ()
    {
        animator = GetComponentInChildren<Animator>();
	}
	

    public void TriggerGrab() => animator.SetTrigger("Grab");
    public void TriggerLet() => animator.SetTrigger("Let");
}

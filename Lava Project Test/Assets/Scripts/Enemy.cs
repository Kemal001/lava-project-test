using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;

    private Rigidbody[] rbs;

    public bool ragdollActivated;

    private void Awake() => animator = GetComponentInChildren<Animator>();

    private void Start()
    {
        rbs = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rb in rbs)
        {
            rb.isKinematic = true;
        }
    }

    public void ActivateRagdoll()
    {
        if(!ragdollActivated)
        {
            animator.enabled = false;

            foreach (Rigidbody rb in rbs)
            {
                rb.isKinematic = false;
            }

            ragdollActivated = true;
        }
    }
}

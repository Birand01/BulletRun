using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UniversalRagdoll : MonoBehaviour
{
   
    protected Rigidbody[] _ragdollRigidbodies;
    protected Collider[] _colliders;
    protected Rigidbody _mainRb;
    protected Collider _mainCollider;
    protected float ragdollEnabilityTime;
    protected Animator animator;
    protected virtual void Awake()
    {
        animator=GetComponent<Animator>();
        _mainRb = GetComponent<Rigidbody>();
        _mainCollider = GetComponent<Collider>();
        _ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        _colliders= GetComponentsInChildren<Collider>();
        DisableRagdoll();
    }

    protected virtual void DisableRagdoll()
    {
        foreach (Rigidbody rb in _ragdollRigidbodies)
        {
            rb.isKinematic = true;

        }
        _mainRb.isKinematic = false;

        foreach (Collider collider in _colliders)
        {
            collider.enabled = false;
        }
        _mainCollider.enabled = true;
    }
    public virtual void EnableRagdoll()
    {
        StartCoroutine(EnableRagdollCoroutine());
    }
    public virtual IEnumerator EnableRagdollCoroutine()
    {
       
        yield return new WaitForSeconds(ragdollEnabilityTime);
        animator.enabled = false;
        foreach (Rigidbody rb in _ragdollRigidbodies)
        {
            rb.isKinematic = false;
        }
        foreach (Collider collider in _colliders)
        {
            collider.enabled = true;
        }
        _mainRb.isKinematic = false;
        _mainCollider.enabled = false;
        _mainRb.AddForce(new Vector3(0, 1, -1), ForceMode.Impulse);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallFly : SetupBehaviour
{
    [SerializeField] protected Rigidbody rb;    
    [SerializeField] protected float force;
    public float slowdownRate = 10; 
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetRigidBody();
    }
    protected virtual void FixedUpdate()
    {
        CannonBallSlowdown();
        CannonFly();
    }    

    protected virtual void CannonBallSlowdown()
    {
        rb.AddForce(Physics.gravity * 9.8f * Time.fixedDeltaTime);
    }
    // Reset all force apply
    protected virtual void OnEnable()
    {
        rb.isKinematic = false;
    }
    protected virtual void OnDisable()
    {
        rb.isKinematic = true;
    }

    protected virtual void GetRigidBody()
    {
        if (rb != null) return;
        rb = GetComponent<Rigidbody>();
        Debug.Log("Reset " + nameof(rb) + " in " + GetType().Name);
    }
    protected virtual void CannonFly()
    {
        if (rb == null) return;
        rb.AddRelativeForce(Vector3.forward * slowdownRate * Time.fixedDeltaTime, ForceMode.Impulse);
    }
    protected virtual float PositiveValue(float value)
    {
        if (value < 0) return -value;
        return value;
    }
}

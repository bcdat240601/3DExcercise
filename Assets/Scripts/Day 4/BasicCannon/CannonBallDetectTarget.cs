using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallDetectTarget : SetupBehaviour
{
    [SerializeField] protected CannonBallController cannonBallController;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetCannonBallController();
    }

    protected virtual void GetCannonBallController()
    {
        if (cannonBallController != null) return;
        cannonBallController = GetComponentInParent<CannonBallController>();
        Debug.Log("Reset " + nameof(cannonBallController) + " in " + GetType().Name);
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Obstacle"))
        {
            CannonBallSpawner.Instance.Despawn(transform.parent);
        }
        if (collider.CompareTag("Score"))
        {
            cannonBallController.CannonController.CannonPoint.AddPoint();
            CannonBallSpawner.Instance.Despawn(transform.parent);
        }
    }
    
}

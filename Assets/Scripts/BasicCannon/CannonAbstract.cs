using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CannonAbstract : SetupBehaviour
{
    [SerializeField] protected CannonController cannonController;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetCannonController();
    }
    protected virtual void GetCannonController()
    {
        if (cannonController != null) return;
        cannonController = GetComponentInParent<CannonController>();
        Debug.Log("Reset " + nameof(cannonController) + " in " + GetType().Name);
    }
}

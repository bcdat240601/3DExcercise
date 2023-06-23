using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CannonConnectUI : SetupBehaviour
{
    [SerializeField] protected CannonUI cannonUI;
    public CannonUI CannonUI =>  cannonUI;

    protected override void Awake()
    {
        base.Awake();
        GetPointText();
    }
    protected virtual void GetPointText()
    {
        if (cannonUI != null) return;
        cannonUI = GameObject.FindObjectOfType<CannonUI>();
        Debug.Log("Reset " + nameof(cannonUI) + " in " + GetType().Name);
    }
}

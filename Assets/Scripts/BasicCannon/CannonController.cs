using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : SetupBehaviour
{
    [SerializeField] protected Transform cannonBarrelRoot;
    public Transform CannonBarrelRoot => cannonBarrelRoot;
    [SerializeField] protected Transform cannonSpawn;
    public Transform CannonSpawn => cannonSpawn;
    [SerializeField] protected CannonStored cannonStored;
    public CannonStored CannonStored => cannonStored;
    [SerializeField] protected CannonConnectUI cannonConnectUI;
    public CannonConnectUI CannonConnectUI => cannonConnectUI;
    [SerializeField] protected CannonPoint cannonPoint;
    public CannonPoint CannonPoint => cannonPoint;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetCannonBarrelRoot();
        GetCannonSpawn();
        GetCannonStored();
        GetCannonConnectUI();
        GetCannonPoint();
    }

    protected virtual void GetCannonPoint()
    {
        if (cannonPoint != null) return;
        cannonPoint = GetComponentInChildren<CannonPoint>();
        Debug.Log("Reset " + nameof(cannonPoint) + " in " + GetType().Name);
    }

    protected virtual void GetCannonConnectUI()
    {
        if (cannonConnectUI != null) return;
        cannonConnectUI = GetComponentInChildren<CannonConnectUI>();
        Debug.Log("Reset " + nameof(cannonConnectUI) + " in " + GetType().Name);
    }
    protected virtual void GetCannonStored()
    {
        if (cannonStored != null) return;
        cannonStored = GetComponentInChildren<CannonStored>();
        Debug.Log("Reset " + nameof(cannonStored) + " in " + GetType().Name);
    }

    protected virtual void GetCannonBarrelRoot()
    {
        if (cannonBarrelRoot != null) return;
        cannonBarrelRoot = transform.Find("Model").Find("CannonBarrelRoot");
        Debug.Log("Reset " + nameof(cannonBarrelRoot) + " in " + GetType().Name);
    }
    protected virtual void GetCannonSpawn()
    {
        if (cannonSpawn != null) return;
        cannonSpawn = transform.Find("Model").Find("CannonBarrelRoot").Find("CannonSpawn");
        Debug.Log("Reset " + nameof(cannonSpawn) + " in " + GetType().Name);
    }
}

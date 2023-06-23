using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonTarget : CannonAbstract
{
    [SerializeField] protected Camera cam;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetCamera();        
    }

    protected virtual void GetCamera()
    {
        if (cam != null) return;
        cam = GameObject.FindObjectOfType<Camera>();
        Debug.Log("Reset " + nameof(cam) + " in " + GetType().Name);
    }

    protected virtual void Update()
    {
        GetMousePosition();
    }
    protected virtual void GetMousePosition()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            cannonController.CannonBarrelRoot.LookAt(hit.point);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonPoint : CannonAbstract
{
    [SerializeField] protected int currentPoint;

    protected override void Awake()
    {
        base.Awake();
        cannonController.CannonConnectUI.CannonUI.OnReplay += ResetPoint;
    }

    protected virtual void ResetPoint()
    {
        currentPoint = 0;
        cannonController.CannonConnectUI.CannonUI.Point.text = currentPoint.ToString();
    }

    public virtual void AddPoint()
    {
        currentPoint += 100;
        cannonController.CannonConnectUI.CannonUI.Point.text = currentPoint.ToString();
    }
}

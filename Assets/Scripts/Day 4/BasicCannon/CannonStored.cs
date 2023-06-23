using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonStored : CannonAbstract
{
    [SerializeField] protected int currentBall;
    public int CurrentBall => currentBall; 
    [SerializeField] protected int maxBall = 10;

    protected override void Awake()
    {
        base.Awake();
        cannonController.CannonConnectUI.CannonUI.OnReplay += ResetBall;
        ResetBall();
    }
    public  virtual void DeductBall()
    {
        currentBall--;
        cannonController.CannonConnectUI.CannonUI.CurrentBall.text = currentBall.ToString();
    }
    public virtual void ResetBall()
    {
        currentBall = maxBall;
        cannonController.CannonConnectUI.CannonUI.CurrentBall.text = currentBall.ToString();
    }
}

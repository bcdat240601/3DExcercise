using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFire : CannonAbstract
{
    [SerializeField] protected float rotateAngle = 1;
    [SerializeField] protected float speed = 2;
    [SerializeField] protected float maxRotate = 100;
    protected virtual void Update()
    {
        ResetForce();
        GetForce();
        FireCannon();
    }
    protected virtual void ResetForce()
    {
        if (!Input.GetKeyDown(0) && !Input.GetKeyDown(KeyCode.Space)) return;
        rotateAngle = 1;
    }
    protected virtual void GetForce()
    {
        if (cannonController.CannonStored.CurrentBall == 0) return;
        if (!Input.GetKey(0) && !Input.GetKey(KeyCode.Space)) return;       
        rotateAngle += speed * Time.deltaTime;
        rotateAngle = Mathf.Clamp(rotateAngle, 1, maxRotate); 
        cannonController.CannonConnectUI.CannonUI.Slider.value = rotateAngle / maxRotate;

    }
    protected virtual void FireCannon()
    {
        if (cannonController.CannonStored.CurrentBall == 0) return;
        if (!Input.GetKeyUp(0) && !Input.GetKeyUp(KeyCode.Space)) return;
        Transform cannonBall = CannonBallSpawner.Instance.GetPrefabBeforeSpawn("CannonBall");
        //rotateAngle = maxRotate + 1 - rotateAngle;
        Debug.Log(rotateAngle);
        cannonBall.GetComponent<CannonBallFly>().slowdownRate = rotateAngle;
        cannonBall.GetComponent<CannonBallController>().CannonController = cannonController;
        CannonBallSpawner.Instance.SpawnAfterGetPrefab(cannonBall, cannonController.CannonSpawn.position, cannonController.CannonBarrelRoot.rotation);
        cannonController.CannonStored.DeductBall();
    }
}

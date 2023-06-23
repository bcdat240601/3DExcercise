using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallSpawner : Spawner
{
    protected static CannonBallSpawner instance;

    public static CannonBallSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null)
        {
            Destroy(this.gameObject);
            Debug.LogError("there's 2 CannonBallSpawner in the scene");
        }
        instance = this;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFly : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb2D;
    [SerializeField] protected float speed;
    protected virtual void Update()
    {
        if (rb2D == null) return;
        rb2D.AddForce(Vector2.left * speed);

    }
}

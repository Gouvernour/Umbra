using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D RB;
    //private bool Facingright = true;

    private void Awake()
    {
        RB.GetComponent<Rigidbody2D>();
    }
    public void Move(float move)
    {
        Vector3 targetVelocity = new Vector2(move * 10f, 0f);
        RB.velocity = targetVelocity;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;

    float Speed = 5f;
    Vector3 lookdirection;

    const float EPSILON = .1f;
    void Update()
    {
        lookdirection = (target.position - transform.position).normalized;

        if ((transform.position - target.position).magnitude > EPSILON) 
            transform.Translate(lookdirection * Time.deltaTime * Speed);
    }
}

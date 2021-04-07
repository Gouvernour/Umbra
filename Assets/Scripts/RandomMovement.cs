using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMovement : MonoBehaviour
{
    bool inNumerator = false;
    float time = 0.57f;

    Vector3 moveDirection;
    public float y = 10f;
    float speed = 0.15f;

    private void Update()
    {
        if (!inNumerator)
            StartCoroutine(bobbing());
        moveDirection.x = 0;
        moveDirection.y = y;
        moveDirection.z = 0;
        moveDirection.Normalize();
        transform.position = transform.position + moveDirection * speed * Time.deltaTime;
    }
    IEnumerator bobbing()
    {
        inNumerator = true;
        yield return new WaitForSeconds(time);
        y = -y;
        inNumerator = false;
    }
}

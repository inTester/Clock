using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CpuController : MonoBehaviour
{
    //[SerializeField] CpuPointer cpuPointerCS = default;
    [SerializeField] Transform cpuPointer = default;
    [SerializeField] float SPEED = 1;
    const float OFFSET = 0.3f;

    void Start()
    {
    }

    void Update()
    {
        Tracking();
    }



    //追尾
    bool Tracking()
    {
        Vector3 velocity = Vector3.zero;
        velocity += cpuPointer.position - transform.position;

        if (Math.Abs(velocity.x) < OFFSET && Math.Abs(velocity.y) < OFFSET)
            return false; //既に近かったらなし

        transform.position += velocity.normalized * SPEED;
        return true;
    }

}

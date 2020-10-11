using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 0.1f;

    void Start()
    {

    }

    void Update()
    {
        Vector3 position = this.transform.position;
        if (Input.GetKey(KeyCode.A))
        {
            position += new Vector3(-1, 0, 0) * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            position += new Vector3(1, 0, 0) * speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            position += new Vector3(0, 1, 0) * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            position += new Vector3(0, -1, 0) * speed;
        }
        this.transform.position = position;

    }
}

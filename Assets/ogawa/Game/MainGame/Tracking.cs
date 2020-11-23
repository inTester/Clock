using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    [SerializeField] Transform target = default;
    Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();

    }
    void Update()
    {
    }
     void LateUpdate()
    {
        this.gameObject.transform.position = target.position;
        rigidbody2D.velocity = new Vector2(0.0000000000000001f, 0.0000000000000001f);
    }
}

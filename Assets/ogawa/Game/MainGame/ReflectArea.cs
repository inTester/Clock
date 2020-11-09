using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectArea : MonoBehaviour
{
    [SerializeField] Transform target = default;

    void Start()
    {
         
    }
    void Update()
    {
    }
     void LateUpdate()
    {
        this.gameObject.transform.position = target.position;
    }
}

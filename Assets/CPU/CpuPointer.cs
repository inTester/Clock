using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CpuPointer : MonoBehaviour
{

    void Start()
    {
    }
    void Update()
    {
    }

    ////範囲外なら追尾する
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("et");
    //    if (collision.gameObject.tag == "pointer")
    //    {
    //        isTracking = false;
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    Debug.Log("ex");
    //    if (collision.gameObject.tag == "pointer")
    //    {
    //        isTracking = true;
    //    }
    //}
}

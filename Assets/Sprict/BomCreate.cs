using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomCreate : MonoBehaviour
{
    [SerializeField] GameObject bom = default;
    [SerializeField] CountText text;
    float startTime;

    void Start()
    {
        float startTime = Time.time;

    }

    void Update()
    {
        float diffTime = Time.time - startTime;

        if (diffTime > 3.0f)
        {
            startTime = Time.time;
           GameObject g = Instantiate(bom, new Vector3(6, 0, 0), Quaternion.identity);
            g.gameObject.GetComponent<Bom>().tcs = text;
        }
    }
}

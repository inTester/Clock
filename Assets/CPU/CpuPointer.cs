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

    //場所を変えるランダム
    public void ChangePos()
    {
        float x = Random.Range(-1.0f, -8.0f);
        float y = Random.Range(4.0f, -4.0f);
        this.transform.position = new Vector3(x, y, 0);
    }
    //特定の場所に行く
    public void ChangePos(Vector3 pos)
    {
        this.transform.position = pos;
    }

}

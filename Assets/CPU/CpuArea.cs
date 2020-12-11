using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CpuArea : MonoBehaviour
{
    [SerializeField] CpuPointer cpuPointer = default;
    List<GameObject> bombOb = new List<GameObject>();
    float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (!ListCheck())
        {
            PointerSet();
        }
        else
        {
            PointerSetBomb();
        }
    }



    //リストが空か
    bool ListCheck()
    {
        if (bombOb.Count > 0)
        {
            return true;
        }
        return false;
    }

    //0だったら一定カウントごとに"場所を変える"を呼び出す
    void PointerSet()
    {
        if (Time.time - startTime > 2.0f)
        {
            cpuPointer.ChangePos();
            startTime = Time.time;
        }
    }

    //1以上だったら"そのcollitionの場所に行く"を呼び出す
    void PointerSetBomb()
    {
        if (bombOb[0] == null) return;
        cpuPointer.ChangePos(bombOb[0].transform.position);
    }

    //爆弾が入ったらリストに入れる
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Bomb") return;
        bombOb.Add(collision.gameObject);
    }
    //出ていったらリストから消す
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Bomb") return;

        for (int i = 0; i < bombOb.Count; i++)
        {
            if (bombOb[i] == null) continue;
            if (bombOb[i].name == collision.name)
            {
                bombOb.RemoveAt(i);
            }
        }
    }
}

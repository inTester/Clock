using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CpuReflection : MonoBehaviour
{
    const float DISTANCE = 4.0f;

    [SerializeField] float POWER;//押し出される力
    List<GameObject> bombOb = new List<GameObject>();

    float startTime;
    //一定時間経過したら飛ばす


    void Update()
    {
        if (bombOb.Count > 0)
        {
            if (Reflect(bombOb[0].GetComponent<Rigidbody2D>()))
                bombOb[0].GetComponent<Bomb_script>().fly = true; //飛ばすフラグをオン
        }
    }

    //枠内に入ったら
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Bomb") return;
        bombOb.Add(collision.gameObject);
        startTime = Time.time;
    }
    //枠から出たら
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Bomb") return;
        for (int i = 0; i < bombOb.Count; i++)
        {
            if (bombOb[i].name == collision.name)
            {
                bombOb.RemoveAt(i);
            }
        }
    }

    //rayで障害物があるかを調べ、指定の方向に飛ばす
    bool Reflect(Rigidbody2D bomRb2D)
    {
        if (Time.time - startTime < 0.05f) return false;

        RaycastHit2D hit;
        //右下
        hit = MySystem.RaycastAndDraw(this.gameObject.transform.position, new Vector2(0.5f, -0.5f), DISTANCE, 1 << 10);
        if (!hit.collider)
        {
            bomRb2D.AddForce(new Vector3(0.5f, -0.5f) * POWER);
            return true;
        }
        //右上
        hit = MySystem.RaycastAndDraw(this.gameObject.transform.position, new Vector3(0.5f, 0.5f), DISTANCE, 1 << 10);
        if (!hit.collider)
        {
            bomRb2D.AddForce(new Vector3(0.5f, 0.5f) * POWER);
            return true;
        }
        //前
        hit = MySystem.RaycastAndDraw(this.gameObject.transform.position, new Vector3(1f, 0f), DISTANCE, 1 << 10);
        if (!hit.collider)
        {
            bomRb2D.AddForce(new Vector3(1f, 0f) * POWER);
            return true;
        }

        //どこも開いていなければ現在地から
        if (this.gameObject.transform.position.y >= 0)
        {
            bomRb2D.AddForce(new Vector3(0.5f, 0.5f) * POWER);
        }
        else
        {
            bomRb2D.AddForce(new Vector3(0.5f, -0.5f) * POWER);
        }
        return true;
    }


}

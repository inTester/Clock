using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_script : MonoBehaviour
{
    [SerializeField] private float Limit = default;//爆発までの総時間(秒)
    [SerializeField] private float power = default;//押し出される力

    private bool fly;//投げられたか
    private float bornTime;//生成時の時間
    private float limitTime;//爆発までの時間

    // Start is called before the first frame update
    void Start()
    {
        bornTime = Time.time;
        fly = false;
    }

    // Update is called once per frame
    void Update()
    {
        Bomb();
        ColorChange();
    }
    void Explosion()
    {
        //爆弾消去
        Destroy(this.gameObject);
    }

    void Bomb()//色換え保留
    {
        limitTime = Time.time - bornTime;
        if (limitTime >= Limit)
        {
            //左右どちらのエリアで爆発したか
            if(this.transform.position.x >= 0)
            {
                GameObject obj = GameObject.Find("ExplosionCountR");
                obj.GetComponent<ExplosionCount_script>().AddCount(1);
            }
            else if(this.transform.position.x <= 0)
            {
                GameObject obj = GameObject.Find("ExplosionCountL");
                obj.GetComponent<ExplosionCount_script>().AddCount(1);
            }
            //爆発
            Explosion();
        }
    }

    void ColorChange()
    {
        if(limitTime >= (Limit / 3) * 2) { GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f,1.0f); }
        else if(limitTime >= (Limit / 3)) { GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.5f, 0.0f,1.0f); }
    }

    //当たり判定↓
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("joystick button 5"))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector3(Input.GetAxis("Horizontal2") * power, Input.GetAxis("Vertical2") * power, 0));
                fly = true;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //飛んでる最中プレイヤーとの接触で爆発
        if(collision.gameObject.tag == "Player")
        {
            if (fly) { Explosion(); }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_script : MonoBehaviour
{
    [SerializeField] private float Limit = default;//爆発までの総時間(秒)
    [SerializeField] private float power = default;//押し出される力
    [SerializeField] AudioClip soundSE = default;//発射音
    AudioSource audioSource;

    private bool fly;//投げられたか
    private float bornTime;//生成時の時間
    private float limitTime;//爆発までの時間

    private float g;//green
    float x, y;

    bool refrect;

    // Start is called before the first frame update
    void Start()
    {
        bornTime = Time.time;
        fly = false;
        g = 1.0f;
        refrect = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Bomb();
        ColorChange();
    }
    void ExplosionR(int i)
    {
        //Rのスコア加算
        GameObject obj = GameObject.Find("ExplosionCountR");
        obj.GetComponent<ExplosionCount_script>().AddCount(i);
        //爆弾生成方向設定
        GameObject obj2 = GameObject.Find("Bomb_Spowner");
        obj2.GetComponent<Bomb_Spowner_script>().SetDir('L');
        //爆弾消去
        Destroy(this.gameObject);
    }
    void ExplosionL(int i)
    {
        //Rのスコア加算
        GameObject obj = GameObject.Find("ExplosionCountL");
        obj.GetComponent<ExplosionCount_script>().AddCount(i);
        //爆弾生成方向設定
        GameObject obj2 = GameObject.Find("Bomb_Spowner");
        obj2.GetComponent<Bomb_Spowner_script>().SetDir('R');
        //爆弾消去
        Destroy(this.gameObject);
    }
    void Effect()
    {
        GameObject obj = GameObject.Find("Particle_system");
        obj.GetComponent<particle_script>().Boon(gameObject.transform.position);
    }
    void Bomb()
    {
        limitTime = Time.time - bornTime;

        if (limitTime >= Limit)
        {
            //positionに爆発エフェクト生成
            Effect();
            //左右どちらのエリアで爆発したか
            if (this.transform.position.x >= 0) { ExplosionL(1); }
            else if (this.transform.position.x <= 0) { ExplosionR(1); }
        }
    }

    void ColorChange()
    {
        float per = 0.3f / ((Limit / 3) * 60);//1フレで減らすG量

        g -= per;
        GetComponent<SpriteRenderer>().color = new Color(1.0f, g, 0.0f, 1.0f);
    }

    //当たり判定↓
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "reflect")
        {
            if (Input.GetKey("joystick 1 button 0") || Input.GetKey("joystick 1 button 3") || Input.GetKey("joystick 1 button 2")
             || Input.GetKey("joystick 2 button 0") || Input.GetKey("joystick 2 button 3") || Input.GetKey("joystick 2 button 1"))
            {
                //ボタン入力で飛ぶ
                fly = true;
                audioSource.PlayOneShot(soundSE);
                //ボタンで方向を決める
                if (Input.GetKey("joystick 1 button 0"))
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector3(-0.5f, -0.5f) * power);
                }
                if (Input.GetKey("joystick 1 button 3"))
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector3(-0.5f, 0.5f) * power);
                }
                if (Input.GetKey("joystick 1 button 2"))
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector3(-1f, 0f) * power);
                }

                if (Input.GetKey("joystick 2 button 0"))
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector3(0.5f, -0.5f) * power);
                }
                if (Input.GetKey("joystick 2 button 3"))
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector3(0.5f, 0.5f) * power);
                }
                if (Input.GetKey("joystick 2 button 1"))
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector3(1f, 0f) * power);
                }
            }
        }
    }
    void Move()
    {
        ////爆弾が何かにぶつかるまで力を加算
        //if (!refrect)
        //{
        //    GetComponent<Rigidbody2D>().AddForce(new Vector3(x * power, -y * power, 0));
        //}
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //飛んでる最中プレイヤーとの接触で爆発
        if (collision.gameObject.tag == "Player")
        {
            if (fly)
            {
                GameObject player_1 = GameObject.Find("Player_1");

                if (collision.gameObject == player_1)
                {
                    //positionに爆発エフェクト生成
                    Effect();
                    //player爆発で移動しない
                    player_1.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                    //点数加算
                    ExplosionL(1);
                }
                else
                {
                    GameObject player_2 = GameObject.Find("Player_2");
                    //positionに爆発エフェクト生成
                    Effect();
                    //player爆発で移動しない
                    player_2.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                    //点数加算
                    ExplosionR(1);
                }
            }
        }
        else if (fly) { refrect = true; }
    }
}

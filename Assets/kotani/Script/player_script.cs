using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float speed;//移動速度
    [SerializeField] private GameObject arr = default;//矢印画像

    //public float[] vec = new float[2];//方向


    void Start()
    {
        //arr.transform.rotation = Quaternion.Euler(0, 0, -90);
        //vec[0] = 1.0f;
        //vec[1] = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = Vector3.zero;
        pos.x = Input.GetAxis("Horizontal");
        pos.y = Input.GetAxis("Vertical");

        transform.position += pos.normalized * speed;


        //プレイヤーの移動
        Vector3 position = this.transform.position;
        if (position.x - GetComponent<Transform>().localScale.x / 2 + Input.GetAxis("Horizontal") * speed > 0)
        {
            position.x += Input.GetAxis("Horizontal") * speed;
        }
        else
        {
            position.x = GetComponent<Transform>().localScale.x / 2;
        }
        position.y += Input.GetAxis("Vertical") * speed;

        ////キーボード対応↓
        //if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.L))
        //{
        //    float dir = 1;
        //    if (Input.GetKey(KeyCode.J)) { dir = -1; }
        //    if (position.x + GetComponent<Transform>().localScale.x / 2 + dir * speed > 0) { position.x += dir * speed; }
        //    else { position.x = GetComponent<Transform>().localScale.x / 2; }
        //}
        //if (Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.K))
        //{
        //    float dir = 1;
        //    if (Input.GetKey(KeyCode.K)) { dir = -1; }
        //    position.y += dir * speed;
        //}

        //this.transform.position = position;
    }
}

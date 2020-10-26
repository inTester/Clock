using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_2_script : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float speed;//移動速度
    [SerializeField] private GameObject arr = default;//矢印画像

    public float[] vec = new float[2];//方向

    void Start()
    {
        arr.transform.rotation = Quaternion.Euler(0, 0, -90);
        vec[0] = 1.0f;
        vec[1] = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーの移動
        Vector3 position = this.transform.position;
        position += new Vector3(Input.GetAxis("Horizontal_2"), Input.GetAxis("Vertical_2"), 0) * speed;
        this.transform.position = position;

        ////画像の回転
        if(Input.GetAxis("Vertical2_2") >= 1.00f || Input.GetAxis("Vertical2_2") <= -1.00f ||
            Input.GetAxis("Horizontal2_2") >= 1.00f || Input.GetAxis("Horizontal2_2") <= -1.00f)
        {
            vec[0] = -Input.GetAxis("Vertical2_2");
            vec[1] = Input.GetAxis("Horizontal2_2");

            float angle = -Mathf.Atan2(-Input.GetAxis("Vertical2_2"), Input.GetAxis("Horizontal2_2")) * Mathf.Rad2Deg;
            arr.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}

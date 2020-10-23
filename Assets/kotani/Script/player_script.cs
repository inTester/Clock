using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float speed;//移動速度
    [SerializeField] private GameObject arr = default;//矢印画像
    
    void Start()
    {
        speed = 0.01f;
        arr.transform.rotation = Quaternion.Euler(0, 0, -90);
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーの移動
        Vector3 position = this.transform.position;
        position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * speed;
        this.transform.position = position;

        ////画像の回転
        if((Input.GetAxis("Vertical2") != 0.00f) ||(Input.GetAxis("Horizontal2") != 0.00f))
        {
            float angle = -Mathf.Atan2(-Input.GetAxis("Vertical2"), Input.GetAxis("Horizontal2")) * Mathf.Rad2Deg;
            arr.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_2_script : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float speed;//移動速度

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーの移動
        Vector3 position = this.transform.position;

        if(position.x + GetComponent<Transform>().localScale.x/2 + Input.GetAxis("Horizontal_2") * speed < 0)
        {
            position.x += Input.GetAxis("Horizontal_2") * speed;
        }
        else { position.x = -GetComponent<Transform>().localScale.x / 2; }
        position.y += Input.GetAxis("Vertical_2") * speed;
        
        //キーボード対応↓
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            float dir = 1;
            if (Input.GetKey(KeyCode.A)) { dir = -1; }
            if(position.x + GetComponent<Transform>().localScale.x / 2 + dir * speed < 0) { position.x += dir * speed; }
            else { position.x = -GetComponent<Transform>().localScale.x / 2; }
        }
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            float dir = 1;
            if (Input.GetKey(KeyCode.S)) { dir = -1; }
            position.y += dir * speed;
        }

        this.transform.position = position;
    }
}

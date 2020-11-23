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
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 vel = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized / 10;
        vel *= speed;

        //キーボード対応↓
        if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.L))
        {
            float dir = 1;
            if (Input.GetKey(KeyCode.J)) { dir = -1; }

            if (((transform.position + vel).x - GetComponent<Transform>().localScale.x / 2) <= 0) { vel.x = 0; }
            else { vel.x = dir * speed * 0.1f; }
        }
        if (Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.K))
        {
            float dir = 1;
            if (Input.GetKey(KeyCode.K)) { dir = -1; }
            vel.y = dir * speed * 0.1f;
        }

        if (((transform.position + vel).x - GetComponent<Transform>().localScale.x / 2) <= 0) { vel.x = 0; }
        this.transform.position += vel;
    }
}

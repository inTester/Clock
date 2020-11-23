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
        Vector3 vel = new Vector3(Input.GetAxis("Horizontal_2"), Input.GetAxis("Vertical_2"), 0).normalized / 10;
        vel *= speed;

        //キーボード対応↓
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            float dir = 1;
            if (Input.GetKey(KeyCode.A)) { dir = -1; }

            if (((transform.position + vel).x + GetComponent<Transform>().localScale.x / 2) >= 0) { vel.x = 0; }
            else { vel.x = dir * speed * 0.1f; }
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            float dir = 1;
            if (Input.GetKey(KeyCode.S)) { dir = -1; }
            vel.y = dir * speed * 0.1f;
        }

        if (((transform.position + vel).x + GetComponent<Transform>().localScale.x / 2) >= 0) { vel.x = 0; }
        this.transform.position += vel;
    }
}

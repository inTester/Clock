using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bom : MonoBehaviour
{
    float startTime;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        rig = this.GetComponent<Rigidbody2D>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        float diffTime = Time.time - startTime;

        spriteRenderer.color -= new Color(0, 0.003f, 0, 0);

        if (diffTime > 5.0f)
        {
            Destroy(this.gameObject);
        }

        Debug.Log(transform.forward);
    }

    float speed = 1000.0f;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.A))
            {
                rig.AddForce(new Vector3(-1, 0, 0) * speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rig.AddForce(new Vector3(1, 0, 0) * speed);
            }
            if (Input.GetKey(KeyCode.W))
            {
                rig.AddForce(new Vector3(0, 1, 0) * speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rig.AddForce(new Vector3(0, -1, 0) * speed);
            }

        }
    }
}

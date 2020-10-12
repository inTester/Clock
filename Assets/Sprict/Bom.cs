using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bom : MonoBehaviour
{
    float startTime;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rig;
    public CountText tcs;
    bool f;

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
            tcs.CountUp(transform);
        }

        if (f)
        {
            if (Input.GetKeyDown("joystick button 5"))
            {
                rig.AddForce(new Vector3(Input.GetAxis("R_stic_H") * 1000, -Input.GetAxis("R_stic_V") * 1000, 0));
            }
        }
    }

    float speed = 1000.0f;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            f = true;
        }
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            f = false;
        }
    }
}

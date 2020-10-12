using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 0.1f;
    [SerializeField] GameObject arr;

    void Start()
    {

    }

    void Update()
    {
        Vector3 position = this.transform.position;
        position += new Vector3(Input.GetAxis("Horizontal"), -Input.GetAxis("Vertical"), 0) * speed;
        this.transform.position = position;

        float radian = Mathf.Atan2(-Input.GetAxis("R_stic_V"), Input.GetAxis("R_stic_H")) * Mathf.Rad2Deg;

        arr.transform.rotation = Quaternion.Euler(0, 0, radian);
    }

}

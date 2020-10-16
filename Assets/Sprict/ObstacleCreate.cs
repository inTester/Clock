using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreate : MonoBehaviour
{
    [SerializeField] GameObject first;
    [SerializeField] GameObject second;
    List<GameObject> f = new List<GameObject>();
    List<GameObject> s = new List<GameObject>();

    bool flag = false;

    void Start()
    {
        f.Add(Instantiate(first, new Vector3(-5.49f, 2.58f, 0), Quaternion.identity));
        f.Add(Instantiate(first, new Vector3(3.49f, -2.58f, 0), Quaternion.identity));
    }

    void Update()
    {
        int time = (int)(30.0f - Time.time);
        if (time < 10 && !flag)
        {
            foreach (GameObject g in f)
            {
                Destroy(g);
            }

            s.Add(Instantiate(second, new Vector3(-2.7f, -3.63f, 0), Quaternion.identity));
            s.Add(Instantiate(second, new Vector3(2.7f, 0.63f, 0), Quaternion.identity));

            flag = true;
        }
    }
}

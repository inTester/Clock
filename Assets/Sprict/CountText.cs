using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountText : MonoBehaviour
{
    [SerializeField] Text r_text;
    [SerializeField] Text l_text;
    int r_count = 0;
    int l_count = 0;

    void Start()
    {

    }

    void Update()
    {
        r_text.text = "右：" + r_count;
        l_text.text = "左：" + l_count;
    }

    public void CountUp(Transform t)
    {
        if (t.position.x > 0)
        {
            r_count++;
        }
        if (t.position.x < 0)
        {
            l_count++;
        }
    }
}

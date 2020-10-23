using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_script : MonoBehaviour
{
    [SerializeField] private int time = default;  //制限時間
    [SerializeField] private Text text = default; //制限時間のテキスト(画像に差し替わるかも)

    private int count;

    // Start is called before the first frame update
    void Start()
    {
        count = time;
    }

    // Update is called once per frame
    void Update()
    {
        count = (int)(time - Time.time);
        text.text = count.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButtonBar : MonoBehaviour
{
    //Slider２つ
    [SerializeField] Slider sliderL = default;
    [SerializeField] Slider sliderR = default;
    [SerializeField] string sceneName = "";

    void Start()
    {
    }

    void Update()
    {
        //両方マックスだったら次へ
        if (sliderL.value >= 1 && sliderR.value >= 1)
        {
            FadeManager.Instance.LoadScene(sceneName, 1.0f);
        }

        //片方マックスだったら相手の入力を待つ表示
        if (sliderL.value >= 1)
        {
            sliderL.gameObject.GetComponentInChildren<Text>().text = "右のプレイヤーを待っています…";
        }
        //マックスでなかったら増やす
        else if (Input.GetKey("joystick 2 button 0") || Input.GetKey(KeyCode.V))
        {
            sliderL.value += 0.01f;
        }
        //途中でやめたら0にする
        else
        {
            sliderL.value = 0;
        }

        //R側
        if (sliderR.value >= 1)
        {
            sliderR.gameObject.GetComponentInChildren<Text>().text = "左のプレイヤーを待っています…";
        }
        else if (Input.GetKey("joystick 1 button 0") || Input.GetKey(KeyCode.B))
        {
            sliderR.value += 0.01f;
        }
        else
        {
            sliderR.value = 0;
        }
    }
}

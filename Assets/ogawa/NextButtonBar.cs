using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButtonBar : MonoBehaviour
{
    //Slider２つ
    [SerializeField] Slider sliderR = default;
    [SerializeField] string sceneName = "";

    void Start()
    {
    }

    void Update()
    {
        //マックスだったら次へ
        if (sliderR.value >= 1)
        {
            FadeManager.Instance.LoadScene(sceneName, 1.0f);
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

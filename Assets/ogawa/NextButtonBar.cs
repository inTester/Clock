using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextButtonBar : MonoBehaviour
{
    //Slider２つ
    [SerializeField] Slider sliderBack = default;
    [SerializeField] Slider sliderNext = default;
    [SerializeField] string sceneNameBack = "Tutorial1";
    [SerializeField] string sceneNameNext = "Select";

    void Start()
    {
    }

    void Update()
    {
        if (sliderBack.value >= 1)
        {
            //FadeManager.Instance.LoadScene(sceneName, 1.0f);
            SceneManager.LoadScene(sceneNameBack);
        }
        else if (Input.GetKey("joystick 1 button 2") || Input.GetKey(KeyCode.G))
        {
            sliderBack.value += 0.01f;
        }
        else
        {
            sliderBack.value = 0;
        }

        //マックスだったら次へ
        if (sliderNext.value >= 1)
        {
            //FadeManager.Instance.LoadScene(sceneName, 1.0f);
            SceneManager.LoadScene(sceneNameNext);
        }
        else if (Input.GetKey("joystick 1 button 0") || Input.GetKey(KeyCode.B))
        {
            sliderNext.value += 0.01f;
        }
        else
        {
            sliderNext.value = 0;
        }
    }
}

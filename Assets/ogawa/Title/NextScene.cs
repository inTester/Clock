using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] string sceneName = "";

    void Start()
    {

    }

    void Update()
    {
        //シーン遷移
        if (Input.GetButtonDown("Next"))
        {
            SceneManager.LoadScene(sceneName);
            //FadeManager.Instance.LoadScene(sceneName,1.0f);
        }
    }


}

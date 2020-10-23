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
        if (Input.GetButtonDown("Enter"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}

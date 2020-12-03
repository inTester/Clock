using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    void Start()
    {
        //マウスカーソルを無効
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}

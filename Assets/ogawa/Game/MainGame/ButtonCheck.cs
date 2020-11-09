﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCheck : MonoBehaviour
{
    enum Mode { LEFT, RIGHT };
    [SerializeField] Mode mode;

    [SerializeField] Image yButton = default;
    [SerializeField] Image xButton = default;
    [SerializeField] Image bButton = default;
    [SerializeField] Image aButton = default;

    void Start()
    {
    }
    void Update()
    {
        switch (mode)
        {
            case Mode.RIGHT:
                if (Input.GetKey("joystick 1 button 3"))
                { yButton.color = Color.white; }
                else
                { yButton.color = Color.gray; }

                if (Input.GetKey("joystick 1 button 2"))
                { xButton.color = Color.white; }
                else
                { xButton.color = Color.gray; }

                if (Input.GetKey("joystick 1 button 0"))
                { aButton.color = Color.white; }
                else
                { aButton.color = Color.gray; }
                break;

            case Mode.LEFT:
                if (Input.GetKey("joystick 2 button 3"))
                { yButton.color = Color.white; }
                else
                { yButton.color = Color.gray; }

                if (Input.GetKey("joystick 2 button 1"))
                { bButton.color = Color.white; }
                else
                { bButton.color = Color.gray; }

                if (Input.GetKey("joystick 2 button 0"))
                { aButton.color = Color.white; }
                else
                { aButton.color = Color.gray; }
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMLlimit : MonoBehaviour
{
    [SerializeField] Time_script time_sp = default;
    [SerializeField] AudioSource audioSource = default;

    void Start()
    {
    }

    void Update()
    {
        //一定時間経過したらピッチを高く
        if (time_sp.timeLimit <= 15)
        {
            audioSource.pitch = 1.7f;
        }
    }
}

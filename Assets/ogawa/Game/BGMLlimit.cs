using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMLlimit : MonoBehaviour
{
    [SerializeField] AudioClip countdownSE = default;
    [SerializeField] AudioClip bgm = default;
    [SerializeField] AudioSource audioSource = default;

    [SerializeField] bool tutoF;
    [SerializeField] GameObject startCount = default;
    [SerializeField] Time_script time_sp = default;

    void Start()
    {
        if (!tutoF)
        {
            audioSource.clip = countdownSE;
            audioSource.volume = 0.8f;
            audioSource.pitch = 1.3f;
            audioSource.Play();
        }
    }

    void Update()
    {
        if (!startCount.activeSelf && audioSource.clip != bgm)
        {
            audioSource.clip = bgm;
            audioSource.volume = 0.5f;
            audioSource.pitch = 1.0f;
            audioSource.Play();
        }

        //一定時間経過したらピッチを高く
        if (time_sp.timeLimit <= 15)
        {
            audioSource.pitch = 1.7f;
        }
    }
}

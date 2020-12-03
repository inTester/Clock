using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource = default;

    [System.Serializable]
    struct Set
    {
        public AudioClip se;
        public KeyCode code_k;
        public string code_j;
    }
    [SerializeField] Set[] set;


    void Start()
    {
    }

    void Update()
    {
        foreach (var s in set)
        {
            if (Input.GetKeyDown(s.code_k) || Input.GetKeyDown(s.code_j))
            { audioSource.PlayOneShot(s.se); }
        }
    }
}

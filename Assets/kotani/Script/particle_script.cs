using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle_script : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] ParticleSystem particle = default;

    bool f,fPre;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Boon(Vector3 pos)
    {
        Instantiate(particle, pos, Quaternion.identity);
    }
}

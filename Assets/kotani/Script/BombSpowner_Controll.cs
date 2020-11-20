using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpowner_Controll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetActive(bool flag)
    {
        if (flag)
        {
            this.gameObject.GetComponent<Bomb_Spowner_script>().enabled = true;
            this.gameObject.GetComponent<Bombs_Spowner_script>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<Bombs_Spowner_script>().enabled = true;
            this.gameObject.GetComponent<Bomb_Spowner_script>().enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_Controll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void SetActive(bool flag)
    {
        if (flag)
        {
            this.gameObject.GetComponent<player_2_script>().enabled = true;
            this.gameObject.GetComponent<CpuController>().enabled = false;
            GameObject.Find("reflectArea_2").GetComponent<CpuReflection>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<CpuController>().enabled = true;
            GameObject.Find("reflectArea_2").GetComponent<CpuReflection>().enabled = true;
            this.gameObject.GetComponent<player_2_script>().enabled = false;
        }
    }

}

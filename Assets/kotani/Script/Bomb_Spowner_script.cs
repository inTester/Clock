using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Spowner_script : MonoBehaviour
{
    [SerializeField] GameObject obj = default;
    [SerializeField] float interval = default;//生成間隔

    float bornTime;//生成した時間
    float count;
    

    // Start is called before the first frame update
    void Start()
    {
        bornTime = Time.time;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        count = Time.time - bornTime;

        if(count >= interval)
        {
            //生成ポジション適当(後で直す)
            Instantiate(obj, new Vector3(Random.Range(-7.0f,7.0f), Random.Range(-4.0f,4.0f), 0), Quaternion.identity);
            bornTime = Time.time;
        }
    }
}

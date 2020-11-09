using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Spowner_script : MonoBehaviour
{
    [SerializeField] GameObject obj = default;
    [SerializeField] float interval = default;//生成間隔
    [SerializeField] float X = default;//生成X座標最大値
    [SerializeField] float Y = default;//生成Y座標最大値

    float bornTime;//生成した時間
    float count;

    char dir;

    // Start is called before the first frame update
    void Start()
    {
        bornTime = Time.time;
        dir = 'R';
    }

    // Update is called once per frame
    void Update()
    {
        count = Time.time - bornTime;

        if(count >= interval)
        {
            //生成ポジション適当(後で直す)
            if(dir == 'R')
            {
                Instantiate(obj, new Vector3(Random.Range(0.0f, X), Random.Range(-Y, Y), 0), Quaternion.identity);
                bornTime = Time.time;
                dir = 'L';
            }
            else if(dir == 'L')
            {
                Instantiate(obj, new Vector3(Random.Range(-X, 0.0f), Random.Range(-Y, Y), 0), Quaternion.identity);
                bornTime = Time.time;
                dir = 'R';
            }
        }
    }
}

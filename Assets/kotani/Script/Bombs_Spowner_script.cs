using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs_Spowner_script : MonoBehaviour
{
    [SerializeField] GameObject obj = default;
    [SerializeField] float X = default;//生成X座標最大値
    [SerializeField] float Y = default;//生成Y座標最大値
    [SerializeField] int interval = default;//生成間隔

    char dir;
    bool flag;

    int bornTime;

    public void SetDir(char bombDir) { dir = bombDir; }

    // Start is called before the first frame update
    void Start()
    {
        dir = 'R';
        flag = false;
        bornTime = (int)Time.time;
    }
    // Update is called onc
    public void SetStart() { flag = true; }
    void Update()
    {
        if(flag && GameObject.Find("Timer").GetComponent<Time_script>().timeLimit > 0)
        {
            if ((int)Time.time - bornTime >= interval)
            {
                if (dir == 'R')
                {
                    Instantiate(obj, new Vector3(Random.Range(0.0f, X), Random.Range(-Y, Y), 0), Quaternion.identity);
                    SetDir('L');
                    bornTime = (int)Time.time;
                }
                else if (dir == 'L')
                {
                    Instantiate(obj, new Vector3(Random.Range(-X, 0.0f), Random.Range(-Y, Y), 0), Quaternion.identity);
                    SetDir('R');
                    bornTime = (int)Time.time;
                }
            }
        }
    }
}

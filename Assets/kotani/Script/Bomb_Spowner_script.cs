using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Spowner_script : MonoBehaviour
{
    [SerializeField] GameObject obj = default;
    [SerializeField] float X = default;//生成X座標最大値
    [SerializeField] float Y = default;//生成Y座標最大値

    char dir;
    bool flag;

    public void SetDir(char bombDir) { dir = bombDir; }

    // Start is called before the first frame update
    public void Start()
    {
        dir = 'R';
        flag = false;
    }
    public void SetStart() { flag = true; }
    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Bomb(Clone)") == null && flag && GameObject.Find("Timer").GetComponent<Time_script>().timeLimit > 0)
        {
            if (dir == 'R')
            {
                Instantiate(obj, new Vector3(Random.Range(0.0f, X), Random.Range(-Y, Y), 0), Quaternion.identity);
            }
            else if (dir == 'L')
            {
                Instantiate(obj, new Vector3(Random.Range(-X, 0.0f), Random.Range(-Y, Y), 0), Quaternion.identity);
            }
        }
    }
}

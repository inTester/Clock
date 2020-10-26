using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplosionCount_script : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Text text = default;//爆発カウントのテキスト

    public int count { get; private set; }//爆発回数

    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Counter:" + count;
    }

    public void AddCount(int i)
    {
        count += i;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultCount : MonoBehaviour
{
    [SerializeField] Text count;
    [SerializeField] Text winner;

    void Start()
    {
    }

    void Update()
    {
    }

    public void CountSet(int l, int r)
    {
        count.text = l + " : " + r;
        if (l == r)
        {
            winner.text = "引き分け";
        }
        else if (l > r)
        {
            winner.text = "プレイヤー１(右)の勝ち";
        }
        else
        {
            winner.text = "プレイヤー2(左)の勝ち";
        }
    }
}

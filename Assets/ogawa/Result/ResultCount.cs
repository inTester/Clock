using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultCount : MonoBehaviour
{
    [SerializeField] Text player1 = default;
    [SerializeField] Text player2 = default;
    [SerializeField] GameObject score1 = default;
    [SerializeField] GameObject score2 = default;

    void Start()
    {
    }

    void Update()
    {
        Next();
    }
    public void Next()
    {
        if(Input.GetKeyDown("joystick 1 button 0"))
        {
            FadeManager.Instance.LoadScene("Select", 1.0f);
        }
        else if(Input.GetKeyDown("joystick 1 button 3"))
        {
            FadeManager.Instance.LoadScene("Title", 1.0f);
        }
    }

    public void CountSet(int l, int r)
    {
        if (l == r)//引き分け
        {
            WinnerText("Draw");
            ScoreText(l,r);
            AnimeFlag(true, true);
        }
        else if (l < r)//右勝ち
        {
            WinnerText(ref player1,ref player2);
            ScoreText(l,r);
            AnimeFlag(true, false);
        }
        else//左勝ち
        {
            WinnerText(ref player2, ref player1);
            ScoreText(l,r);
            AnimeFlag(false, true);
        }
    }

    void ScoreText(int l,int r)
    {
        score1.GetComponent<Text>().text = r.ToString();
        score2.GetComponent<Text>().text = l.ToString();
    }
    void AnimeFlag(bool p1,bool p2)
    {
        score1.GetComponent<Animator>().enabled = p1;
        score2.GetComponent<Animator>().enabled = p2;
    }
    void WinnerText(ref Text p1,ref Text p2)
    {
        p1.text = "Win!!";
        p2.text = "Lose…";
    }
    void WinnerText(string tex)
    {
        player1.text = tex;
        player2.text = tex;
    }
}

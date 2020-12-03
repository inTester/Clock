using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCount : MonoBehaviour
{
    [SerializeField] bool TutoF;
    [SerializeField] private Text text;
    private int startTime;
    public bool flag { get; private set; }
    public bool end { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        text.fontSize = 200;
        gameObject.SetActive(true);
        startTime = (int)Time.time;
        flag = false;
        end = false;

        //チュートリアル用
        if (TutoF)
        {
            flag = true;
            GameObject.Find("Bomb_Spowner").GetComponent<Bomb_Spowner_script>().SetStart();
            GameObject.Find("Timer").GetComponent<Time_script>().SetStartFlag();
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        //カウント3秒
        int time = 3 - (int)(Time.time - startTime);

        if (time == 0)
        {
            text.text = "GO!";
            if (!flag)
            {
                flag = true;
                GameObject.Find("Bomb_Spowner").GetComponent<Bomb_Spowner_script>().SetStart();
                GameObject.Find("Bomb_Spowner").GetComponent<Bombs_Spowner_script>().SetStart();
                GameObject.Find("Timer").GetComponent<Time_script>().SetStartFlag();

            }
        }
        else if (!end) { text.text = time.ToString(); }
        if (time < 0 && !end) { gameObject.SetActive(false); }
    }
    public void End()
    {
        end = true;
        text.fontSize = 100;
        gameObject.SetActive(true);
        text.text = "TIME UP!";
    }
}

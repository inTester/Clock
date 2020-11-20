using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Time_script : MonoBehaviour
{
    [SerializeField] bool tutoF = false;

    [SerializeField] private int time = default;  //制限時間
    [SerializeField] private Text text = default; //制限時間のテキスト

    [SerializeField] ExplosionCount_script exp_L;
    [SerializeField] ExplosionCount_script exp_R;

    //[SerializeField] GameObject particle;
    [SerializeField] GameObject obj;

    private int startTime; //開始時間
    public bool flag { get; private set; }
    bool startFlag;
    public int timeLimit { get; private set; } //残り時間
    int timeLimitPre;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        startTime = (int)Time.time;

        SetTime(); //時間経過の表示
        flag = false;
        startFlag = false;
        text.text = "";
        if (tutoF)
        { text.text = "60"; }

    }
    public void SetStartFlag()
    {
        startFlag = true;
        startTime = (int)Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if (startFlag && !tutoF)
        {
            SetTime(); //時間経過の表示
                       //ゲーム終了
            if ((timeLimit) <= 0)
            {
                obj.GetComponent<StartCount>().End();
                if (timeLimit != timeLimitPre) { for (int i = 0; i < 8; i++) { /*Instantiate(particle, new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-4.0f, 4.0f), 0), Quaternion.identity); */} }
                if (timeLimit <= -2)
                {
                    if (!flag)
                    {
                        SceneManager.sceneLoaded += GameSceneLoaded;
                        //FadeManager.Instance.LoadScene("Result", 0.2f);
                        SceneManager.LoadScene("Result");
                    }
                    flag = true;
                }
            }
        }
        timeLimitPre = timeLimit;
    }

    //時間経過の表示
    void SetTime()
    {
        int elapsedTime = (int)(Time.time - startTime); //経過時間 
        timeLimit = time - elapsedTime; //経過時間から制限時間をひく、
        //時間描画
        if (timeLimit <= 0)
        {
            text.text = "";
        }
        else { text.text = timeLimit.ToString(); }
    }

    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        // シーン切り替え後のスクリプトを取得
        var resultcount = GameObject.Find("CountText").GetComponent<ResultCount>();
        // データを渡す処理
        resultcount.CountSet(exp_L.count, exp_R.count);
        // イベントから削除
        SceneManager.sceneLoaded -= GameSceneLoaded;
    }
}
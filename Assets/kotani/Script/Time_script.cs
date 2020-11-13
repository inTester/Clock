using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Time_script : MonoBehaviour
{
    [SerializeField] private int time = default;  //制限時間
    [SerializeField] private Text text = default; //制限時間のテキスト

    [SerializeField] ExplosionCount_script exp_L;
    [SerializeField] ExplosionCount_script exp_R;

    private int startTime; //開始時間
    bool flag;
    bool startFlag;
    public int timeLimit { get; private set; } //残り時間

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        startTime = (int)Time.time;
        text.text = "";

        SetTime(); //時間経過の表示
        flag = false;
        startFlag = false;
    }
    public void SetStartFlag()
    {
        startFlag = true;
        startTime = (int)Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if (startFlag)
        {
            SetTime(); //時間経過の表示
                       //ゲーム終了
            if ((timeLimit) <= 0 && !flag)
            {
                //SceneManager.sceneLoaded += GameSceneLoaded;
                //SceneManager.LoadScene("Result");    // シーン切り替え
                flag = true;
                FadeManager.Instance.LoadScene("Result", 2.0f);
            }
        }
    }

    //時間経過の表示
    void SetTime()
    {
        int elapsedTime = (int)(Time.time - startTime); //経過時間 
        timeLimit = time - elapsedTime; //経過時間から制限時間をひく、
        //時間描画
        if (timeLimit <= 0) { text.text = 0.ToString(); }
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
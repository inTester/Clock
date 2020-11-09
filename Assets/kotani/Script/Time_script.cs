using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Time_script : MonoBehaviour
{
    [SerializeField] private int time = default;  //制限時間
    [SerializeField] private Text text = default; //制限時間のテキスト(画像に差し替わるかも)

    [SerializeField] ExplosionCount_script exp_L;
    [SerializeField] ExplosionCount_script exp_R;

    private int startTime; //開始時間
    public int timeLimit { get; private set; } //残り時間

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        startTime = (int)Time.time;

        SetTime(); //時間経過の表示
    }

    // Update is called once per frame
    void Update()
    {
        SetTime(); //時間経過の表示

        //ゲーム終了
        if ((timeLimit) <= 0)
        {
            SceneManager.sceneLoaded += GameSceneLoaded;
            SceneManager.LoadScene("Result");    // シーン切り替え
        }
    }

    //時間経過の表示
    void SetTime()
    {
        int elapsedTime = (int)(Time.time - startTime); //経過時間 
        timeLimit = time - elapsedTime; //経過時間から制限時間をひく、
        text.text = timeLimit.ToString();
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

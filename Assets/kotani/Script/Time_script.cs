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

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        startTime = (int)Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        int elapsedTime = (int)(Time.time - startTime); //経過時間 
        text.text = (time - elapsedTime).ToString(); //経過時間から制限時間をひく、

        //ゲーム終了
        if ((time - elapsedTime) <= 0)
        {
            SceneManager.sceneLoaded += GameSceneLoaded;
            SceneManager.LoadScene("Result");    // シーン切り替え
        }
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

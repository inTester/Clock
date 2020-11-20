using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Button_script : MonoBehaviour
{
    [SerializeField] EventSystem system = default;
    [SerializeField] Button first = default;//最初に選択中のボタン
    int count1,count2;//文字送りのカウント

    public static Text text1;
    public static Text text2;
    

    // Start is called before the first frame update
    void Start()
    {
        first.Select();
        text1 = GameObject.Find("Canvas/Button_sec1/Text").GetComponent<Text>();
        text2 = GameObject.Find("Canvas/Button_sec2/Text").GetComponent<Text>();
        count1 = 0;
        count2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (system.currentSelectedGameObject.gameObject.name)
        {
            default:
                return;

            case "Button_sec1":
                TextChange(ref count1, text1, "一つずつ生成", "複数生成","Canvas/Button_sec1");
                break;
            case "Button_sec2":
                TextChange(ref count2, text2, "二人対戦用", "一人対戦用", "Canvas/Button_sec2");
                break;
            case "Button_return":
                SceneChange("Tutorial");
                break;
            case "Button_start":
                SceneManager.sceneLoaded += GameSceneLoaded;
                SceneChange("Game");
                break;
        }
    }

    void TextChange(ref int counter,Text tex,string st1,string st2,string objName)
    {
        //スティック操作されていない時は即切り替え可能
        if(Input.GetAxis("Horizontal") == 0) { counter = 0; }
        //文字送りのカウント
        if (counter > 0) { counter--; }
        //テキスト入れ替え(項目の種類が増えた際は書き換えが必要)
        if ((Input.GetAxis("Horizontal") > 0.8f || Input.GetAxis("Horizontal") < -0.8f) && counter == 0)
        {
            if (tex.text == st1) { tex.text = st2; }
            else { tex.text = st1; }
            counter = 80;
        }
    }
    //void ButtonActive(Image[] images)
    //{
    //    //入力された時の画像の動き
    //    //右
    //    if (Input.GetAxis("Horizontal") > 0.8f)
    //    {
    //        images[0].color = new Color(255, 100, 100);
    //    }
    //    else { images[0].color = new Color(255, 255, 255); }
    //    //左
    //    if(Input.GetAxis("Horizontal") < -0.8f) { images[1].color = new Color(100, 100, 100); }
    //    else { images[1].color = new Color(255, 255, 255); }
    //}

    void SceneChange(string SceneName)
    {
        if (Input.GetKeyDown("joystick 1 button 0"))
        {
            FadeManager.Instance.LoadScene(SceneName, 1.0f);
        }
    }
    private void GameSceneLoaded(Scene Game, LoadSceneMode mode)
    {
        // シーン切り替え後のスクリプトを取得
        var spowner = GameObject.Find("Bomb_Spowner").GetComponent<BombSpowner_Controll>();
        // データを渡す処理
        spowner.SetActive(text1.text == "一つずつ生成");
        // イベントから削除
        SceneManager.sceneLoaded -= GameSceneLoaded;

    }
}

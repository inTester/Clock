using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Button_script : MonoBehaviour
{
    [SerializeField] [TextArea(3, 3)] string[] description;
    [SerializeField] Text text = default;

    [SerializeField] EventSystem system = default;
    //[SerializeField] Button first = default;//最初に選択中のボタン
    int count1, count2;//文字送りのカウント

    public static Text text1;
    public static Text text2;

    bool flag1, flag2;

    [SerializeField] AudioClip next = default;
    [SerializeField] AudioClip select = default;
    [SerializeField] AudioSource audioSource = default;

    // Start is called before the first frame update
    void Start()
    {
        //first.Select();
        text1 = GameObject.Find("Canvas/Button_sec1/Text").GetComponent<Text>();
        text1.text = "１つずつ";
        text2 = GameObject.Find("Canvas/Button_sec2/Text").GetComponent<Text>();
        text2.text = "２人";
        count1 = 0;
        count2 = 0;
        flag1 = true;
        flag2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        switch (system.currentSelectedGameObject.gameObject.name)
        {
            default:
                return;

            case "Button_sec1":
                TextChange(ref count1, text1, "１つずつ", "複数", ref flag1);
                if (flag1)
                { text.text = "今ある爆弾が爆発してから次の爆弾が出現します。\n初心者向け。"; }
                else
                { text.text = "一定時間ごとに爆弾が出現します。\n上級者向け。"; }
                break;
            case "Button_sec2":
                TextChange(ref count2, text2, "２人", "１人", ref flag2);
                if (flag2)
                { text.text = "対人モード。\nコントローラーを２つ使います。"; }
                else
                { text.text = "対CPUモード。\n右側のコントローラー使います。"; }
                break;
            case "Button_return":
                SceneChange("Tutorial2");
                break;
            case "Button_start":
                SceneManager.sceneLoaded += GameSceneLoaded;
                SceneChange("Game");
                break;
        }

    }

    void TextChange(ref int counter, Text tex, string st1, string st2, ref bool flag)
    {
        //スティック操作されていない時は即切り替え可能
        if (Input.GetAxis("Horizontal") == 0) { counter = 0; }
        //文字送りのカウント
        if (counter > 0) { counter--; }
        //テキスト入れ替え(項目の種類が増えた際は書き換えが必要)
        if ((Input.GetAxis("Horizontal") > 0.8f || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.L) || Input.GetAxis("Horizontal") < -0.8f) && counter == 0)
        {
            audioSource.PlayOneShot(select);
            if (tex.text == st1)
            {
                tex.text = st2;
                flag = false;
            }
            else
            {
                tex.text = st1;
                flag = true;
            }
            counter = 80;
        }
    }
    void SceneChange(string SceneName)
    {
        if (Input.GetButtonDown("Next"))
        {
            audioSource.PlayOneShot(next);
            SceneManager.LoadScene(SceneName);
            //FadeManager.Instance.LoadScene(SceneName, 1.0f);
        }
    }
    private void GameSceneLoaded(Scene Game, LoadSceneMode mode)
    {
        // シーン切り替え後のスクリプトを取得
        var spowner = GameObject.Find("Bomb_Spowner").GetComponent<BombSpowner_Controll>();
        var player = GameObject.Find("Player_2").GetComponent<Player2_Controll>();
        // データを渡す処理
        spowner.SetActive(flag1);
        player.SetActive(flag2);
        // イベントから削除
        SceneManager.sceneLoaded -= GameSceneLoaded;
    }
}

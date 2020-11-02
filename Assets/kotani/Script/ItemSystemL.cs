using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSystemL : MonoBehaviour
{
    [SerializeField] GameObject cursor;
    [SerializeField] float X = default, Y = default;//基準座標
    [SerializeField] float scal = default;//拡縮比

    private int cursorNum;//選択番号
    private int count;
    GameObject cursorObj;

    List<GameObject> bombs = new List<GameObject>();//アイテムオブジェクト

    // Start is called before the first frame update
    void Start()
    {
        cursorObj = cursor;
        cursorNum = 0;
        count = 0;
    }
    public bool Flag()
    {
        if (count < 4) { return true; }
        else { return false; }
    }
    void SetCount(int i) { count += i; }

    // Update is called once per frame
    void Update()
    {
        float x = X;
        for (int i = 0; i < bombs.Count; i++)
        {
            if (bombs[i] != null)
            {
                bombs[i].GetComponent<Transform>().localScale = new Vector3(0.3f, 0.3f, 0.0f);
                bombs[i].GetComponent<Transform>().position = new Vector3(x, Y, 0);
                x -= scal * 2;
            }
            else
            {
                bombs.RemoveAt(i);
                SetCount(-1);
            }
        }
        Select();
        Push();
    }
    public void PickUp(GameObject obj)//アイテム追加
    {
        SetCount(1);
        bombs.Add(obj);
    }
    void Select()//アイテム選択
    {
        //一旦仮置き
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.C))
        {
            if (Input.GetKeyDown(KeyCode.C) && cursorNum > 0) { cursorNum--; }
            if (Input.GetKeyDown(KeyCode.Z) && cursorNum < 4) { cursorNum++; }
        }
        float x = X - ((scal * 2) * cursorNum);
        cursorObj.GetComponent<Transform>().position = new Vector3(x, Y, 0);
    }
    public void Push()//アイテム引き出し
    {
        if (Input.GetKeyDown(KeyCode.Space) && bombs.Count > 0 && (bombs[cursorNum] != null))
        {
            //所持アイテム数カウント
            SetCount(-1);

            GameObject p = GameObject.Find("Player_2");
            Vector3 pos = p.GetComponent<Transform>().position;

            //現オブジェクトのコピーを生成
            GameObject obj = bombs[cursorNum];
            obj.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
            obj.GetComponent<Transform>().position = pos;
            obj.GetComponent<Bomb_script>().SetItem(false);
            //アイテムリストのオブジェクトを削除
            bombs.RemoveAt(cursorNum);
        }
    }
}

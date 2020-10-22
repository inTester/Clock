using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleManager : MonoBehaviour
{
    //予測画像
    [SerializeField] Image nextImage = default;
    //使用予定の障害物
    [System.Serializable]
    [SerializeField]
    struct ObstacleSetData
    {
        public GameObject obstacle;
        public Sprite sprite;
        public Vector2[] position;
    }
    [SerializeField] List<ObstacleSetData> obstacleDatas = new List<ObstacleSetData>();

    //使用中の障害物
    float startTime = 0;
    const int MAX_TIME = 4; //障害物変更時間
    int index = 0;
    List<GameObject> nowObstacles = new List<GameObject>();

    //ステータス
    enum State
    { NONE, SELECT, CREATE, MOVE, DESTRY }
    State state;

    void Start()
    {
        //初期化
        //最初の障害物を選ぶ
        RandomSelect();
        state = State.CREATE;
    }

    void Update()
    {

        switch (state)
        {
            case State.NONE:
                break;

            case State.CREATE:
                Create(); //障害物の生成
                          //g.transform.localScale -= new Vector3(-1, -1, 0);
                TimeStart(); //生成時間の記録
                state = State.SELECT;
                break;

            case State.SELECT:
                RandomSelect(); //次の障害物の選択
                state = State.MOVE;
                break;

            case State.MOVE:
                //一定時間を超えたら
                if (TimeCheck())
                {
                    state = State.DESTRY;
                }
                break;

            case State.DESTRY:
                foreach (GameObject g in nowObstacles)
                {
                    //g.transform.localScale -= new Vector3(-1, -1, 0);
                    Destroy(g); //削除
                }
                state = State.CREATE;
                break;
        }
    }


    void RandomSelect()
    {
        //ランダムで障害物を選ぶ
        index = Random.Range(0, obstacleDatas.Count);
        //予測画像を表示
        nextImage.sprite = obstacleDatas[index].sprite;
    }
    void Create()
    {
        //決まった座標に生成
        for (int p = 0; p < obstacleDatas[index].position.Length; p++)
        {
            nowObstacles.Add( //生成したオブジェクトを保持しておく
                Instantiate(obstacleDatas[index].obstacle,
                            new Vector3(obstacleDatas[index].position[p].x, obstacleDatas[index].position[p].y, 0),
                            Quaternion.identity)
                );
        }
    }


    public void TimeStart()
    {
        //生成時間の記録
        startTime = Time.time;
    }
    public bool TimeCheck()
    {
        //一定時間を超えたら
        if (Time.time - startTime > MAX_TIME)
        {
            return true;
        }
        return false;
    }
}

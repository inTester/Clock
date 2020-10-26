using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleManager : MonoBehaviour
{
    //予測画像
    [SerializeField] Image nextImage = default;
    [SerializeField] int MAX_TIME = 20; //障害物変更時間

    //使用予定の障害物
    [System.Serializable]
    [SerializeField]
    struct ObstacleData
    {
        [Header("オブジェクト")]
        public GameObject obstacle; //障害物オブジェクト
        [Header("生成座標"), Tooltip("上記のオブジェクトがsize分 生成されます")]
        public Vector2[] position; //位置
    }
    [System.Serializable]
    [SerializeField]
    struct ObstacleSetData
    {
        [Header("障害物のデータ"), Tooltip("size1つが1パーツ分です")]
        public ObstacleData[] obstacleData; //障害物の情報
        [Header("予測用画像")]
        public Sprite sprite; //予測画像
    }
    [SerializeField, Header("障害物の設定"), Tooltip("size1つが1セット分です")]
    List<ObstacleSetData> obstacleSetDatas = new List<ObstacleSetData>();

    //使用中の障害物
    float startTime = -1;
    List<Obstacle> nowObstaclesOb = new List<Obstacle>();
    ObstacleSetData nowobstacleData = default;
    bool endF = false;

    //ステータス
    enum State
    { NONE, SELECT, CREATE, MOVE, DESTRY, END }
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
                //障害物の生成
                if (!Create()) //無ければendへ
                {
                    state = State.END;
                    break;
                }
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
                foreach (Obstacle cs in nowObstaclesOb)
                {
                    cs.EndAnimation(); //アニメーション実行&削除
                }
                nowObstaclesOb.Clear(); //リスト初期化
                state = State.CREATE;
                break;

            case State.END:
                Debug.Log("end");
                break;
        }
    }


    void RandomSelect()
    {
        if (obstacleSetDatas.Count <= 0)
        {
            nowobstacleData = default;
            endF = true;
            return;
        }

        //ランダムで障害物を選ぶ
        int nextindex = Random.Range(0, obstacleSetDatas.Count);
        //予測画像を表示
        nextImage.sprite = obstacleSetDatas[nextindex].sprite;
        //保存し、候補から削除
        nowobstacleData = obstacleSetDatas[nextindex];
        obstacleSetDatas.RemoveAt(nextindex);
    }
    bool Create()
    {
        if (endF)
        {
            return false;
        }

        //決まった座標に生成
        for (int d = 0; d < nowobstacleData.obstacleData.Length; d++)
        {
            for (int p = 0; p < nowobstacleData.obstacleData[d].position.Length; p++)
            {
                //一旦変数化
                var data = nowobstacleData.obstacleData[d];
                //生成
                GameObject g = Instantiate(data.obstacle,
                                           data.position[p],
                                           Quaternion.identity);
                //スクリプト保存
                nowObstaclesOb.Add(g.GetComponent<Obstacle>());
            }
        }
        return true;
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

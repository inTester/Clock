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
    float startTime = 0;
    const int MAX_TIME = 4; //障害物変更時間
    int index = 0;
    List<Obstacle> nowObstacles = new List<Obstacle>();

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
                foreach (Obstacle cs in nowObstacles)
                {
                    cs.EndAnimation(); //アニメーション実行&削除
                }
                nowObstacles.Clear(); //リスト初期化
                state = State.CREATE;
                break;
        }
    }


    void RandomSelect()
    {
        //ランダムで障害物を選ぶ
        index = Random.Range(0, obstacleSetDatas.Count);
        //予測画像を表示
        nextImage.sprite = obstacleSetDatas[index].sprite;
    }
    void Create()
    {
        //決まった座標に生成
        for (int d = 0; d < obstacleSetDatas[index].obstacleData.Length; d++)
        {
            for (int p = 0; p < obstacleSetDatas[index].obstacleData[d].position.Length; p++)
            {
                //一旦変数化
                var data = obstacleSetDatas[index].obstacleData[d];
                //生成
                GameObject g = Instantiate(data.obstacle,
                                           data.position[p],
                                           Quaternion.identity);
                //スクリプト保存
                nowObstacles.Add(g.GetComponent<Obstacle>());
            }
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

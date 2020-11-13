using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCount : MonoBehaviour
{
    [SerializeField] private Text text;
    private int startTime;
    public bool flag { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);

        startTime = (int)Time.time;
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        //カウント3秒
        int time = 3 - (int)(Time.time - startTime);
        text.text = time.ToString();
        if (time <= 0 && !flag)
        {
            flag = true;
            gameObject.SetActive(false);
            GameObject.Find("Bomb_Spowner").GetComponent<Bomb_Spowner_script>().SetStart();
            GameObject.Find("Timer").GetComponent<Time_script>().SetStartFlag();
        }
    }
}

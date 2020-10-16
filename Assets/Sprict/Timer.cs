using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] GameObject[] Numbers = default;
    GameObject forstDigit_ob;
    GameObject secondDigit_ob;

    int secondDigit = 0;
    int forstDigit = 0;
    int b_secondDigit = 0;
    int b_forstDigit = 0;

    void Start()
    {
        //表示
        forstDigit_ob = Instantiate(Numbers[forstDigit], new Vector3(2, 0, 0), Quaternion.identity);
        secondDigit_ob = Instantiate(Numbers[secondDigit], new Vector3(-2, 0, 0), Quaternion.identity);
    }

    void Update()
    {
        int time = (int)(30.0f - Time.time);
        if (time < 0)
        {
            return;
        }


        //2桁目_1桁目を消して桁下げして切り捨て
        int _time = time;
        secondDigit = (int)Mathf.Floor((_time - (_time % 10)) * 0.1f);
        //1桁目_２桁目を消す
        _time = time;
        forstDigit = (int)Mathf.Floor(_time - (_time / 10 * 10.0f));

        //表示
        if (forstDigit != b_forstDigit)
        {
            Destroy(forstDigit_ob);
            forstDigit_ob = Instantiate(Numbers[forstDigit], new Vector3(2, 0, 10), Quaternion.identity);
        }
        if (secondDigit != b_secondDigit)
        {
            Destroy(secondDigit_ob);
            secondDigit_ob = Instantiate(Numbers[secondDigit], new Vector3(-2, 0, 10), Quaternion.identity);
        }

        b_secondDigit = secondDigit;
        b_forstDigit = forstDigit;
    }
}

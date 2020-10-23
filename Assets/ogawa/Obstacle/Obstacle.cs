using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    const float animationTime = 0.2f;

    void Start()
    {
        //大きさの保存
        Vector3 scale = this.gameObject.transform.localScale;

        //大きさを0にする
        this.gameObject.transform.localScale = Vector3.zero;
        //元の大きさにするアニメーション
        var tween = DOTween.Sequence();
        tween.Append(transform.DOScale(scale, animationTime))
                .SetEase(Ease.Linear);
        tween.Play();
    }

    void Update()
    {

    }

    public void EndAnimation()
    {
        //大きさを0にするアニメーション
        var tween = DOTween.Sequence();
        tween.Append(transform.DOScale(Vector3.zero, animationTime))
                .SetEase(Ease.Linear);
        tween.Play();

        //削除
        tween.OnComplete(() =>
        {
            Destroy(this.gameObject);
        });
    }
}

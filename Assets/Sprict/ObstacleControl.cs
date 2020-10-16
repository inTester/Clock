using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleControl : MonoBehaviour
{
    enum MoveType { NONE, YOKO, TATE };
    [SerializeField] MoveType moveType;

    void Start()
    {
        switch (moveType)
        {
            case MoveType.NONE:
                break;
            case MoveType.YOKO:
                var sequence = DOTween.Sequence();
                sequence.Append(transform.DOMoveX(this.transform.position.x + 3.0f, 1f))
                        .SetEase(Ease.Linear);
                sequence.Append(transform.DOMoveX(this.transform.position.x, 1f))
                        .SetEase(Ease.Linear);
                sequence.SetLoops(-1);
                sequence.Play();
                break;
            case MoveType.TATE:
                var sequencey = DOTween.Sequence();
                sequencey.Append(transform.DOMoveY(this.transform.position.y + 3.0f, 1f))
                        .SetEase(Ease.Linear);
                sequencey.Append(transform.DOMoveY(this.transform.position.y, 1f))
                        .SetEase(Ease.Linear);
                sequencey.SetLoops(-1);
                sequencey.Play();
                break;
        }
    }

    void Update()
    {

    }
}

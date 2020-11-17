using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySystem : MonoBehaviour
{

    //Rayの表示時間
    private const float RAY_DISPLAY_TIME = 3;
    /// Rayを飛ばすと同時に画面に線を描画する
    public static RaycastHit2D RaycastAndDraw(Vector2 origin, Vector2 direction, float maxDistance, int layerMask = 10)
    {
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, maxDistance, layerMask);

        //衝突時のRayを画面に表示
        if (hit.collider)
        {
            Debug.DrawRay(origin, hit.point - origin, Color.blue, RAY_DISPLAY_TIME, false);
        }
        //非衝突時のRayを画面に表示
        else
        {
            Debug.DrawRay(origin, direction * maxDistance, Color.green, RAY_DISPLAY_TIME, false);
        }

        return hit;
    }
}

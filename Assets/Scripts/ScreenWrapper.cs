using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour {


    float radius;

    CircleCollider2D circleCollider;

    // Use this for initialization
    void Start () {
        circleCollider = GetComponent<CircleCollider2D>();
        radius = circleCollider.radius;
    }

    void OnBecameInvisible()
    {
        Vector3 position = transform.position;

        //if (transform.position.x + radius >= ScreenUtils.ScreenRight || transform.position.x -radius <= ScreenUtils.ScreenLeft)
        //Since we are using the OnBecameInvisible method,its not necessay to plus or minis the radius since it does not effct anything is this case.

        if (transform.position.x >= ScreenUtils.ScreenRight || transform.position.x <= ScreenUtils.ScreenLeft)
        {
            position.x = -position.x;
        }
        // if (transform.position.y + radius>= ScreenUtils.ScreenTop || transform.position.y -radius<= ScreenUtils.ScreenBottom)
        // Same as above.

        if (transform.position.y >= ScreenUtils.ScreenTop || transform.position.y <= ScreenUtils.ScreenBottom)
        {
            position.y = -position.y;
        }
        transform.position = position;
    }
}

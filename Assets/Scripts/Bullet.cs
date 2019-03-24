using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Rigidbody2D rgbd2d;

    const float lifeTime = 2f;

    [SerializeField]
    Timer deathTimer;

	// Use this for initialization
	void Start () {
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = lifeTime;
        deathTimer.Run();
	}
	
	// Update is called once per frame
	void Update () {
        if (deathTimer.Finished)
        {
            Destroy(gameObject);
        }
	}

    public void ApplyForce(Vector2 direction)
    {
        const float magnitude = 6f;
        GetComponent<Rigidbody2D>().AddForce(magnitude * direction, ForceMode2D.Impulse);
    }
}

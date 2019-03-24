using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    [SerializeField]
    float maxForce;
    [SerializeField]
    float minForce;

    [SerializeField]
    Sprite[] sprites;

    [HideInInspector]
    public Vector3 originalLocalScale;

    float speedFactor;

    float angle;
    Vector2 moveDirection = new Vector2();
    // Use this for initialization
    void Start () {

    }

    public void Initializer(Directions direction , Vector2 location)
    {
        originalLocalScale = transform.localScale;
        transform.position = location;
        int selection = Random.Range(0, 3);
        GetComponent<SpriteRenderer>().sprite = sprites[selection];
        angle = Random.Range(-1 / 12 * Mathf.PI, 1 / 12 * Mathf.PI) + (float)direction * 0.5f * Mathf.PI;
        StartMoving(angle);
    }

    void StartMoving(float angle)
    {
        moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        speedFactor = Random.Range(minForce, maxForce);
        GetComponent<Rigidbody2D>().AddForce(speedFactor * moveDirection, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Bullet")
        {
            AudioManager.PlayAudio(AudioClipName.BulletsHitAsteroids);
            Destroy(collision2D.gameObject);
            Vector3 localScale = transform.localScale;
            if (localScale.x < originalLocalScale.x * 0.5)
            {
                Destroy(gameObject);
            }
            else
            {
                localScale *= 0.5f;
                transform.localScale = localScale;
                GetComponent<CircleCollider2D>().radius *= 0.5f;
                HaveASon();
                HaveASon();
                Destroy(gameObject);
            }

        }
    }

    void HaveASon() {
        Asteroid sonAsteroid = Instantiate(gameObject).GetComponent<Asteroid>();
        float angle = Random.Range(0, 2 * Mathf.PI);
        sonAsteroid.StartMoving(angle);
        sonAsteroid.originalLocalScale = originalLocalScale;
    }
}

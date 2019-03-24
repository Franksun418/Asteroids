using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    Rigidbody2D rgbd2d;

    Vector2 thrustDirection = new Vector2(1, 0);


    const float thrustForce = 5f;
    const float rotateDegreesPerSecond = 200f;

    [SerializeField]
    GameObject prefabBullet;

    [SerializeField]
    HUD hUD;


    // Use this for initialization
    void Start () {
        rgbd2d = GetComponent<Rigidbody2D>();

	}

    void Update() {
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            AudioManager.PlayAudio(AudioClipName.ShootingBullets);
            Bullet bullet = Instantiate(prefabBullet).GetComponent<Bullet>();
            bullet.transform.position = this.transform.position;
            bullet.transform.localRotation = transform.localRotation;
            bullet.ApplyForce(thrustDirection);
        }
    }


	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetAxis("Thrust") > 0)
        {
            rgbd2d.AddForce(thrustForce * thrustDirection, ForceMode2D.Force);
            //float rad = Mathf.Deg2Rad * transform.eulerAngles.z;
            //thrustDirection = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        }

        if (Input.GetAxis("Rotate") != 0)
        {
            float rotationAmount = rotateDegreesPerSecond * Time.deltaTime;
            if (Input.GetAxis("Rotate") < 0)
            {
                rotationAmount *= -1;
            }
            transform.Rotate(Vector3.forward, rotationAmount);
            float rad = Mathf.Deg2Rad * transform.eulerAngles.z;
            thrustDirection = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Asteroid")
        {
            AudioManager.PlayAudio(AudioClipName.ShipDestoryed);
            hUD.StopTimer();
            Destroy(gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour {

    [SerializeField]
    TextMeshProUGUI scoreText;

    bool timerRunning = true;

    float elapsedTime;

    // Use this for initialization
    void Start () {
        scoreText.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
        if (timerRunning)
        {
            elapsedTime += Time.deltaTime;
            scoreText.text = ((int)elapsedTime).ToString();
        }
	}

    public void StopTimer() {
        timerRunning = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioSource : MonoBehaviour {
    private void Awake()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        AudioManager.Initializer(audioSource);
    }
}

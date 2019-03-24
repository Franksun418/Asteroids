using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager {
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> allAudios = new Dictionary<AudioClipName, AudioClip>();

    public static void Initializer(AudioSource source) {
        audioSource = source;
        allAudios.Add(AudioClipName.BulletsHitAsteroids, Resources.Load<AudioClip>("BulletsHitAsteroids"));
        allAudios.Add(AudioClipName.ShipDestoryed, Resources.Load<AudioClip>("ShipDestoryed"));
        allAudios.Add(AudioClipName.ShootingBullets, Resources.Load<AudioClip>("ShootingBullets"));
    }

    public static void PlayAudio(AudioClipName audioClipName)
    {
        audioSource.PlayOneShot(allAudios[audioClipName]);
    }
}

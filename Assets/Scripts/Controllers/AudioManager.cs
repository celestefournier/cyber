using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] List<SoundAudioClip> soundAudioClips;

    [Serializable]
    public class SoundAudioClip
    {
        public Sound sound;
        public AudioClip audioClip;
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Play(Sound sound)
    {
        var audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundAudioClips.Find(audio => audio.sound == sound).audioClip;

        if (sound is Sound.SwordAttack ||
            sound is Sound.Laser ||
            sound is Sound.DamageEnemy ||
            sound is Sound.EnemyDied)
        {
            audioSource.pitch = Random.Range(0.7f, 1.6f);
        }

        audioSource.Play();

        StartCoroutine(DestroyOnFinish(audioSource, audioSource.clip.length));
    }

    IEnumerator DestroyOnFinish(AudioSource audioSource, float time)
    {
        var safeDelay = 0.2f;
        yield return new WaitForSeconds(time + safeDelay);
        Destroy(audioSource);
    }
}

public enum Sound
{
    Select,
    Back,
    DamagePlayer,
    GameOver,
    SwordAttack,
    DamageEnemy,
    EnemyDied,
    Laser,
    LevelUp,
    SelectUpgrade
}

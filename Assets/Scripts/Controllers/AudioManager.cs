using System;
using System.Collections.Generic;
using UnityEngine;

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
        audioSource.Play();
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

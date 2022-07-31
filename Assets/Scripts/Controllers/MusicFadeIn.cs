using DG.Tweening;
using UnityEngine;

public class MusicFadeIn : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] float volume = 1;

    void Start()
    {
        var audioSource = GetComponent<AudioSource>();

        audioSource.volume = 0;
        audioSource.DOFade(volume, 1);
    }
}

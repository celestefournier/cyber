using DG.Tweening;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    void Start()
    {
        var audioSource = GetComponent<AudioSource>();

        audioSource.volume = 0;
        audioSource.DOFade(1, 1);
    }
}

using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] GameController gameController;

    TextMeshProUGUI textComponent;
    TimeSpan elapsedTime;

    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        StartCoroutine(Count());
    }

    IEnumerator Count()
    {
        textComponent.text = elapsedTime.ToString(@"mm\:ss");

        while (!gameController.gameOver)
        {
            yield return new WaitForSecondsRealtime(1);
            elapsedTime += TimeSpan.FromSeconds(1);

            textComponent.text = elapsedTime.ToString(@"mm\:ss");
        }
    }
}

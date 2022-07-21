using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] GameController gameController;

    [HideInInspector]
    public TimeSpan elapsedTime;
    [HideInInspector]
    public float totalSeconds => (float) elapsedTime.TotalSeconds;

    TextMeshProUGUI textComponent;

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
            yield return new WaitForSeconds(1);
            elapsedTime += TimeSpan.FromSeconds(1);

            textComponent.text = elapsedTime.ToString(@"mm\:ss");
        }
    }
}

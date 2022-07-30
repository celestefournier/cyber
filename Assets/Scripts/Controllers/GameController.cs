using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TextMeshProUGUI goldsEarned;
    [SerializeField] GameObject joystick;

    [HideInInspector]
    public bool gameOver;

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver = true;
        gameOverScreen.SetActive(true);
        joystick.SetActive(false);

        var golds = player.totalExperience * 2;

        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) + golds);
        DOTween.To(() => 0, gold => goldsEarned.text = $"{gold}G", golds, 1)
            .SetEase(Ease.Linear).SetUpdate(true);

        AudioManager.Instance.Play(Sound.GameOver);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}

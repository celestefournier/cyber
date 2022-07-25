using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject joystick;

    [HideInInspector]
    public bool gameOver;

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver = true;
        gameOverScreen.SetActive(true);
        joystick.SetActive(false);
        PlayerPrefs.SetInt("Money", player.experience);
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

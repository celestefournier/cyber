using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject menuScreen;
    [SerializeField] GameObject skillsScreen;

    public void Play()
    {
        AudioManager.Instance.Play(Sound.Select);
        SceneManager.LoadScene("Game");
    }

    public void OpenMenu()
    {
        AudioManager.Instance.Play(Sound.Back);
        menuScreen.SetActive(true);
        skillsScreen.SetActive(false);
    }

    public void OpenSkills()
    {
        AudioManager.Instance.Play(Sound.Select);
        menuScreen.SetActive(false);
        skillsScreen.SetActive(true);
    }
}

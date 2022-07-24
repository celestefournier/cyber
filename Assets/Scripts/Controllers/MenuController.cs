using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject menuScreen;
    [SerializeField] GameObject skillsScreen;

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenMenu()
    {
        menuScreen.SetActive(true);
        skillsScreen.SetActive(false);
    }

    public void OpenSkills()
    {
        menuScreen.SetActive(false);
        skillsScreen.SetActive(true);
    }
}

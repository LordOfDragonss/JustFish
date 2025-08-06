using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonHandler : MonoBehaviour
{

    public MenuBasic HowToPlayScreen;
    public HowToNavigation HowToNavigation;
    public MenuBasic Settings;

    private void Start()
    {
        AudioManager.instance.Play("MenuTheme");
    }

    public void StartGame()
    {
        AudioManager.instance.Stop("MenuTheme");
        SceneManager.LoadScene(1);
    }


    public void OpenHowToPlay()
    {
        HowToPlayScreen.Show();
        HowToNavigation.StartHowTo();
    }

    public void OpenSettings()
    {
        Settings.Show();
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}

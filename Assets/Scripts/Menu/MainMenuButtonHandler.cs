using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonHandler : MonoBehaviour
{

    public MenuBasic HowToPlayScreen;
    public HowToNavigation HowToNavigation;
    public MenuBasic Settings;
    public void StartGame()
    {
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

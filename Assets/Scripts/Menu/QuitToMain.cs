using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitToMain : MonoBehaviour
{

    public void QuitToMainMenu()
    {
        AudioManager.instance.Stop("GameTheme");
        AudioManager.instance.Stop("Reel");
        SceneManager.LoadScene(0);
    }
}

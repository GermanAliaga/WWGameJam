using UnityEngine;
using UnityEngine.SceneManagement;

public class S_MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("S_Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

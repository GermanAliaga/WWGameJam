using UnityEngine;
using UnityEngine.SceneManagement;

public class S_PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject QuitMenu;
    public void ResetPauseMenu()
    {
        PauseMenu.SetActive(true);
        QuitMenu.SetActive(false);
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene("S_MainMenu");
    }
}

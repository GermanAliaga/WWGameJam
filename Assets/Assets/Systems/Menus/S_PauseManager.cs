using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class S_PauseManager : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] private GameObject PauseMenu;
    void Update()
    {
        
    }
    public void OnPause()
    {
        Pause();
    }
    public void Pause()
    {
        Debug.Log("a");
        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0;
            PauseMenu.SetActive(true);

        }
        else if (isPaused)
        {
            Debug.Log("b");
            Time.timeScale = 1;
            PauseMenu.GetComponentInChildren<S_PauseMenu>().ResetPauseMenu();
            PauseMenu.SetActive(false);
            isPaused = false;
        }
    }
}

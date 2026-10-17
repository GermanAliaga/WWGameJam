using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Concurrent;

public class UIcontroller : MonoBehaviour
{
    public GameObject pantallaConfiguraciones;
    public GameObject pantallaPausa;

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        pantallaPausa.SetActive(true);
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        pantallaPausa.SetActive(false);
        Time.timeScale = 1;
    }

    public void Jugar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("CharacterSelection");
    }

    public void Reiniciar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuInicio()
    {
        SceneManager.LoadScene("S_MainMenu");
    }

    public void Configuraciones()
    {
        SceneManager.LoadScene("PantallaConfiguraciones");
    }

    public void Configuraciones2()
    {
        pantallaPausa.SetActive(false);
        pantallaConfiguraciones.SetActive(true);
    }

    public void Volver()
    {

        SceneManager.LoadScene("MainMenu");
    }

    public void Volver3()
    {
        pantallaConfiguraciones.SetActive(false);
        pantallaPausa.SetActive(true);
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("close");
    }
}
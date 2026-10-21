using System;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{
    ///  
    /// VALOR MÁXIMO DE LA CORRUPCIÓN DEBERÍA DE SER COMO 150 
    /// 

    public static float valorCorrup;

    public static Vector3 posicionPJ;
    public static string escenaAnter;

    public GameObject jugador;
    public KitsuneBehaviour kitsune1;
    public Kitsune2 kitsune2;
    public Kitsune3 kitsune3;
    public Kitsune4 kitsune4;

    public static int ka1;
    public static int ka2;
    public static int ka3;
    public static int ka4;

    private Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        animator = GetComponent<Animator>();
        if (animator) { animator.SetFloat("percent", valorCorrup); }
        if (jugador) 
        { 
            if (jugador.GetComponent<PlayerMovements>()) 
            { 
                jugador.GetComponent<PlayerMovements>().SetPosition(posicionPJ);
            } 
        }
        if (SceneManager.GetActiveScene().name == "S_MainMenu")
        {
            valorCorrup = 0;
            posicionPJ = new Vector3(0,0,0);
            ka1 = 0; ka2 = 0; ka3 = 0; ka4 = 0;
            Debug.Log(ka1 + " / " + ka2 + " / " + ka3 + " / " + ka4);
        }
        VerificacionKitsune();
        Debug.Log(ka1 + " / " + ka2 + " / " + ka3 + " / " + ka4);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "S_Game")
            return;

        VerificacionKitsune();
    }

    public void VerificacionKitsune()
    {
        if (kitsune1.ayuda && ka1 == 1)
        {
            ProcesarKitsune(kitsune1.agregCorrup);
            ka1 = 2;
            kitsune1.ayuda = false;
            posicionPJ = jugador.transform.position;
        }
        else if(ka1 == 2) { kitsune1.gameObject.SetActive(false); }

        if (kitsune2.ayuda && ka2 == 1)
        {
            ProcesarKitsune(kitsune2.agregCorrup);
            ka2 = 2;
            kitsune2.ayuda = false;
            posicionPJ = jugador.transform.position;
        }
        else if (ka2 == 2) { kitsune2.gameObject.SetActive(false); }

        if (kitsune3.ayuda && ka3 == 1)
        {
            ProcesarKitsune(kitsune3.agregCorrup);
            ka3 = 2;
            kitsune3.ayuda = false;
            posicionPJ = jugador.transform.position;
        }
        else if (ka3 == 2) { kitsune3.gameObject.SetActive(false); }

        if (kitsune4.ayuda && ka4 == 1)
        {
            ProcesarKitsune(kitsune4.agregCorrup);
            ka4 = 2;
            kitsune4.ayuda = false;
            posicionPJ = jugador.transform.position;
        }
        else if (ka4 == 2) { kitsune4.gameObject.SetActive(false); }
    }

    private void ProcesarKitsune(bool agregaCorrupcion)
    {
        valorCorrup += agregaCorrupcion ? 10 : -10;

        // Limitar la corrupción al rango de 0 a 150.
        valorCorrup = Mathf.Clamp(valorCorrup, 0f, 150f);

        animator.SetFloat("percent", valorCorrup);

        Debug.Log("Valor de corrupción: " + valorCorrup);
        Debug.Log("Estado ka1 y ka2: " + ka1 + "; " + ka2);
    }

    // Update is called once per frame
    /*void Update()
    {
        if((kitsune1.ayuda == true && ka1 == 1) || (kitsune2.ayuda == true && ka2 == 1))
        {
            Debug.Log("valor ka1 y ka2:" + ka1 + "; " + ka2);
            VerificacionKitsune();
        }
    }

    public void VerificacionKitsune()
    {
        if(SceneManager.GetActiveScene().name == "S_Game")
        {
            if ((kitsune1.agregCorrup == true && ka1 == 1) || (kitsune2.agregCorrup == true && ka2 == 1))
            {
                Debug.Log("valor ka1 y ka2:" + ka1 + "; " + ka2);
                if(kitsune1.agregCorrup == true && ka1 == 1)
                {
                    ka1 = 2;
                }
                else if (kitsune2.agregCorrup == true && ka2 == 1)
                {
                    ka2 = 2;
                }
                valorCorrup += 10;
                animator.SetFloat("percent", valorCorrup);

                Debug.Log("valor ka1 y ka2:" + ka1 + "; " + ka2);
                Debug.Log("valor corrupcion: " + valorCorrup);
            }
            else if ((kitsune1.agregCorrup == false && ka1 == 1) || (kitsune2.agregCorrup == false && ka2 == 1))
            {
                Debug.Log("valor ka1 y ka2:" + ka1 + "; " + ka2);
                if (kitsune1.agregCorrup == false && ka1 == 1)
                {
                    ka1 = 2;
                }
                else if (kitsune2.agregCorrup == false && ka2 == 1)
                {
                    ka2 = 2;
                }
                valorCorrup -= 10;
                animator.SetFloat("percent", valorCorrup);

                Debug.Log("valor ka1 y ka2:" + ka1 + "; " + ka2);
                Debug.Log("valor corrupcion: " + valorCorrup);
            }
        }        
    }*/

    public void AumentoCorruption(bool agregaCorrupcion)
    {
        valorCorrup += agregaCorrupcion ? 10 : -10;

        // Limitar la corrupción al rango de 0 a 150.
        valorCorrup = Mathf.Clamp(valorCorrup, 0f, 150f);

        animator.SetFloat("percent", valorCorrup);
        Debug.Log("Valor de corrupción: " + valorCorrup);
    }

    public void CheckEndLevel()
    {
        if(valorCorrup <= 20)
        {
            SceneManager.LoadScene("Ending3");
        }
        else if (valorCorrup > 20 && valorCorrup <= 80)
        {
            SceneManager.LoadScene("Ending2");
        }
        else if (valorCorrup > 80 && valorCorrup <= 150)
        {
            SceneManager.LoadScene("Ending3");
        }
    }

}

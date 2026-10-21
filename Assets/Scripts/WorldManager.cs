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
    public KitsuneBehaviour kitsune3;
    public KitsuneBehaviour kitsune4;

    public static int ka1 = 0;
    public static int ka2 = 0;

    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        valorCorrup = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if((kitsune1.ayuda == true && ka1 == 1) || (kitsune2.ayuda == true && ka2 == 1) ||( kitsune3.ayuda == true) || (kitsune4.ayuda == true))
        {
            VerificacionKitsune();
        }
    }

    public void VerificacionKitsune()
    {
        if ((kitsune1.agregCorrup == true && ka1 == 1) || (kitsune2.agregCorrup == true && ka2 == 1) || (kitsune3.agregCorrup == true) || (kitsune4.agregCorrup == true))
        {
            ka1 = 2;
            ka2 = 2;
            valorCorrup += 10;
            animator.SetFloat("percent", valorCorrup);
        }
        else if ((kitsune1.agregCorrup == false && ka1 == 1) || (kitsune2.agregCorrup == false && ka2 == 1) || (kitsune3.agregCorrup == false) || (kitsune4.agregCorrup == false))
        {
            ka1 = 2;
            ka2 = 2;
            valorCorrup -= 10;
            animator.SetFloat("percent", valorCorrup);
        }
    }
}

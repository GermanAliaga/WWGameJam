using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{
    ///  
    /// VALOR MÁXIMO DE LA CORRUPCIÓN DEBERÍA DE SER COMO 150 
    /// 

    public static float valorCorrup = 0;

    public static Vector3 posicionPJ;
    public static string escenaAnter;

    public GameObject jugador;
    public KitsuneBehaviour kitsune1;
    public KitsuneBehaviour kitsune2;
    public KitsuneBehaviour kitsune3;
    public KitsuneBehaviour kitsune4;

    private bool ayudar;

    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(valorCorrup > -1)
        {
            animator.SetFloat("percent", valorCorrup);
        }
    }
}

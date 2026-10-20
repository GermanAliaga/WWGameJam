using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{
    [SerializeField] private float rotation = 10;
    public static Vector2 posicionPJ;
    public static string escenaAnter;

    public GameObject jugador;
    public KitsuneBehaviour kitsune1;
    public KitsuneBehaviour kitsune2;
    public KitsuneBehaviour kitsune3;
    public KitsuneBehaviour kitsune4;

    private bool ayudar;    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ayudar = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(SceneManager.GetActiveScene().name != "Laberinto" || SceneManager.GetActiveScene().name != "S_Sokoban")
        {
            
        }*/
    }

    /*public void AyudaBrindada()
    {
        if (kitsune1.ayuda == true)
        {

        }
        else if (kitsune2.ayuda == true)
        {

        }
        else if (kitsune3.ayuda == true)
        {

        }
        else if (kitsune4.ayuda == true)
        {

        }
    }*/

    public void CorruptionUp()
    {
        if(ayudar)
        {
            if(transform.rotation.z > -90 && ayudar == true)
            {
                transform.localEulerAngles = new Vector3(0, 0, transform.rotation.z - rotation);
            }
        }
    }

    public void CorruptionDown()
    {
        if(transform.rotation.z < 90 && ayudar == true)
        {
            transform.localEulerAngles = new Vector3(0, 0, transform.rotation.z + rotation);
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Kitsune3 : MonoBehaviour
{
    public GameObject kitsune;
    public GameObject dialogo;
    public GameObject player;
    public string sceneExtra;

    public float amplitud;
    public float frecuencia;

    private Vector2 posicionIni;
    private float desplazamientoY;

    public bool ayuda;

    public bool agregCorrup;

    [Header("Animacion")]
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicionIni = transform.position;
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        dialogo.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        desplazamientoY = Mathf.Sin(Time.time * frecuencia) * amplitud;
        transform.position = new Vector2(posicionIni.x, desplazamientoY + posicionIni.y);
        if (ayuda == true)
        {
            SeleccionOpcNo();
        }
    }

    private void FixedUpdate()
    {
        animator.SetBool("ayuda", false);
    }

    public void SeleccionOpcSi()
    {
        ayuda = true;
        WorldManager.ka3 = 1;
        WorldManager.posicionPJ = player.transform.position;
        WorldManager.escenaAnter = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene(sceneExtra);
    }

    public void SeleccionOpcNo()
    {
        dialogo.SetActive(false);
        animator.SetBool("ayuda", true);
    }

    public void DesactivarK()
    {
        kitsune.SetActive(false);
    }
}

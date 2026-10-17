using UnityEngine;

public class SpiritBehaviour : MonoBehaviour
{
    public GameObject dialogo;

    public float amplitud;
    public float frecuencia;

    private Vector2 posicionIni;
    private float desplazamientoY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicionIni = transform.position;
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
    }
}

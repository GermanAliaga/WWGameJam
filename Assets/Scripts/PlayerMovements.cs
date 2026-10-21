using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMovements : MonoBehaviour
{
    public Rigidbody2D rb;

    [Header("Movimiento")]
    private float horizontal = 0f; // Para el moviemiento del personaje en x, ademas de la orientacion que este tiene en el eje
    [SerializeField] private float velMov; // Velocidad de movimiento del jugador
    [SerializeField] private float suavVelMov;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = false;
    private bool correr = false;

    [Header("Salto")]
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private LayerMask sueloCapa;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool isOnGround;
    private bool salto = false;

    [Header("Animacion")]
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * velMov;

        animator.SetFloat("Horizontal", Mathf.Abs(horizontal));

        if (Input.GetButtonDown("Jump"))
        {
            salto = true;
        }

        if (Input.GetButton("Run"))
        {
            correr = true;
        }
    }

    private void FixedUpdate()
    {
        isOnGround = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, sueloCapa);
        animator.SetBool("enSuelo", isOnGround);
        animator.SetBool("correr", correr);

        Mover(horizontal * Time.fixedDeltaTime, salto, correr);

        salto = false;
        correr = false;
    }

    public void SetPosition(Vector3 position_)
    {
        transform.position = position_;
    }

    private void Mover(float mover, bool saltar, bool run)
    {

        if (correr && run)
        {
            Vector3 velObjetivo = new Vector2(mover * 2, rb.linearVelocity.y);
            rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, velObjetivo, ref velocidad, suavVelMov);
        }
        else
        {
            Vector3 velObjetivo = new Vector2(mover, rb.linearVelocity.y);
            rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, velObjetivo, ref velocidad, suavVelMov);
        }

        if (mover > 0 && mirandoDerecha)
        {
            Girar();
        }
        else if (mover < 0 && !mirandoDerecha)
        {
            Girar();
        }

        if (isOnGround && saltar)
        {
            isOnGround = false;
            rb.AddForce(new Vector2(0f, fuerzaSalto));
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }
}

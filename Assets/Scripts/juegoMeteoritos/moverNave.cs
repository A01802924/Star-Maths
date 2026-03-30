using UnityEngine;
using UnityEngine.InputSystem;

public class moverNave : MonoBehaviour
{
    [SerializeField]
    private InputAction iaMove;
    [SerializeField]
    private InputAction iaImpulso;
    [SerializeField]
    private InputAction iaDisparo;

    private float velocidad = 10f;
    private float impulso = 20f;
    private float duracionImpulso = 0.2f;
    private float cooldownImpulso = 1f;
    private float timerImpulsando;
    private float cooldownTimer;
    private bool impulsando;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        relojImpulso();
        if (impulsando) return;

        Vector2 mov = iaMove.ReadValue<Vector2>();
        rb.linearVelocity = mov * velocidad;
    }

    void OnEnable()
    {
        iaMove.Enable();
        iaImpulso.Enable();

        iaImpulso.performed += Impulso;
    }

    void OnDisable()
    {
        iaImpulso.Disable();
        iaImpulso.performed -= Impulso;
    }

    public void Impulso(InputAction.CallbackContext context)
    {
        if (impulsando || cooldownTimer > 0)
        {
            return;
        }

        Vector2 direccion = iaMove.ReadValue<Vector2>();

        if (direccion == Vector2.zero)
        {
            direccion = Vector2.right;
        }

        impulsando = true;
        timerImpulsando = duracionImpulso;
        cooldownTimer = cooldownImpulso;

        rb.linearVelocity = Vector2.zero;
        rb.linearVelocity = direccion.normalized * impulso;
    }

    void relojImpulso()
    {
        if (!impulsando && cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            return;
        }

        timerImpulsando -= Time.deltaTime;

        if (timerImpulsando <= 0 && impulsando)
        {
            impulsando = false;
        }
    }
}
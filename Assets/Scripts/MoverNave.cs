using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem; 
using UnityEngine.Rendering; 
public class MoverInputAction : MonoBehaviour { 
    [SerializeField] 
    private InputAction accionMover; 
    //Mover en las 4 direcciones 
    [SerializeField] 
    private InputAction accionImpulso; 
    private float velocidadX = 35f; 
    private float velocidadY = 35f; 
    private float fuerzaImpulso = 8f; 
    private Rigidbody2D rb; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created 
    void Start() { 
    //Habilitar InputAction 
    accionMover.Enable(); 
    accionImpulso.Enable(); rb = GetComponent<Rigidbody2D>(); 
    } 

    void OnEnable() { 
        accionImpulso.performed += impulsar;
    } 
    void OnDisable() { 
        accionImpulso.performed -= impulsar;
    } 
    public void impulsar(InputAction.CallbackContext context) { 
        rb.AddForce(Vector2.up * fuerzaImpulso, ForceMode2D.Impulse); 
    }

    // Update is called once per frame 
    void FixedUpdate()
    {
        Vector2 movimiento = accionMover.ReadValue<Vector2>();
        rb.AddForce(
            new Vector2(movimiento.x * velocidadX, movimiento.y * velocidadY),
            ForceMode2D.Force
        );
    }
}
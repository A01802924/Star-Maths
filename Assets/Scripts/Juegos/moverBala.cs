using UnityEngine;

public class moverBala : MonoBehaviour
{
    private Rigidbody2D rb;
    private float velocidad = 15f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1.5f);
    }

    void FixedUpdate()
    {
        rb.linearVelocityX = velocidad * 1;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Meteorito"))
        {
            Destroy(gameObject);
        }
    }
}
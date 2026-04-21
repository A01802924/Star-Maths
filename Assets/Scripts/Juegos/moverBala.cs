using UnityEngine;

public class moverBala : MonoBehaviour
{
    private Rigidbody2D rb;
    private float velocidad = 15f;
    [SerializeField] private GameObject efectoChoque;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1.2f);
    }

    void FixedUpdate()
    {
        rb.linearVelocityX = velocidad * 1;
        if (transform.position.x >= 10f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Meteorito"))
        {
            Destroy(gameObject);
            Instantiate(efectoChoque, transform.position, transform.rotation);
        }
    }
}
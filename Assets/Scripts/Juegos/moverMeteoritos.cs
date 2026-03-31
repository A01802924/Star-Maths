using UnityEngine;

public class moverMeteoritos : MonoBehaviour
{
    private Rigidbody2D rb;
    private float velocidad = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocityX = velocidad * -1;
    }

    public void perder()
    {
        Destroy(gameObject);
    }
}
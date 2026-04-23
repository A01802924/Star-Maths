using UnityEngine;

public class moverMeteoritos : MonoBehaviour
{
    private Rigidbody2D rb;
    private float velocidad = 6.7f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocityX = velocidad * -1;
        if (transform.position.x <= -14)
        {
            destruirMeteoritos();
            vidaNave.instance.meteoritosPerdidos++;
        }
    }

    public void destruirMeteoritos()
    {
        Destroy(gameObject);
    }
}
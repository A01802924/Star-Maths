using UnityEngine;

public class barreraBalas : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bala"))
        {
            Destroy(collision.gameObject);
        }
    }
}
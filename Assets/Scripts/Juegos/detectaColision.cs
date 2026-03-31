using UnityEngine;

public class detectaColision : MonoBehaviour
{
    private moverMeteoritos meteoros;

    void Start()
    {
        meteoros = GetComponentInParent<moverMeteoritos>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || transform.position.x <= -13)
        {
            meteoros.perder();
        }
        if (collision.CompareTag("Bala"))
        {
            Destroy(gameObject);
        }
    }
}
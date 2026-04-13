using UnityEngine;

public class detectaColision : MonoBehaviour
{
    private moverMeteoritos meteoros;
    private bool golpeo = false;

    void Start()
    {
        meteoros = GetComponentInParent<moverMeteoritos>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (golpeo)
        {
            return;
        }
        if (collision.CompareTag("Player"))
        {
            golpeo = true;
            vidaNave.instance.vidas--;
            meteoros.perder();
            MenuPausa.instance.ActualizarVidas();
        }
        if (collision.CompareTag("Bala"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
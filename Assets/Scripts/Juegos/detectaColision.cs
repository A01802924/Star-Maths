using UnityEngine;

public class detectaColision : MonoBehaviour
{
    private moverMeteoritos meteoros;
    private bool golpeo = false;
    public bool valor;

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
            if (valor)
            {
                vidaNave.instance.correctas++;
            }
            
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
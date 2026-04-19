using UnityEngine;

public class detectaColisionJefe : MonoBehaviour
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
            meteoros.destruirMeteoritos();
        }
        if (collision.CompareTag("Player"))
        {
            golpeo = true;
            meteoros.destruirMeteoritos();
            MenuPausa.instance.ActualizarVidas();
        }
        if (collision.CompareTag("Bala"))
        {
            meteoros.destruirMeteoritos();
            Destroy(collision.gameObject);
        }
    }
}
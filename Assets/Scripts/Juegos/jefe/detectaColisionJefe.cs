using UnityEngine;

public class detectaColisionJefe : MonoBehaviour
{
    private moverMeteoritos meteoros;
    private Animator anim;
    private bool golpeo = false;
    private int rand;

    void Start()
    {
        rand = Random.Range(1, 3);

        meteoros = GetComponentInParent<moverMeteoritos>();
        anim = GetComponent<Animator>();

        if (rand == 2)
        {
            anim.SetTrigger("2");
        }
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
using Assets.Scripts.Core;
using UnityEngine;

public class detectaColision : MonoBehaviour
{
    private moverMeteoritos meteoros;
    private bool golpeo = false;
    private int valor;
    private Animator anim;
    private int rand;

    void Start()
    {
        rand = Random.Range(1, 3);
        anim = GetComponent<Animator>();

        meteoros = GetComponentInParent<moverMeteoritos>();
        if (transform.position.y >= 0f)
        {
            valor = 1;
        } else
        {
            valor = 2;
        }

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
            if (valor == SessionData.meteoritoCorrecto)
            {
                MenuPausa.instance.ActualizarCorrectas(5);
                if (vidaNave.instance.correctas >= 5)
                {
                    vidaNave.instance.Ganar(5);
                    
                }
            } else
            {
                MenuPausa.instance.ActualizarVidas();
            }

            controladorOperaciones.instance.generarOperacion(Random.Range(1, 3));

            meteoros.destruirMeteoritos();
            Destroy(collision.gameObject);
        }
    }
}
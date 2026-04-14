using Assets.Scripts.Core;
using UnityEngine;

public class detectaColision : MonoBehaviour
{
    private moverMeteoritos meteoros;
    private bool golpeo = false;
    private int valor;

    void Start()
    {
        meteoros = GetComponentInParent<moverMeteoritos>();
        if (transform.position.y == 2.8f)
        {
            valor = 1;
        } else
        {
            valor = 2;
        }
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
            if (valor == SessionData.meteoritoCorrecto)
            {
                vidaNave.instance.correctas++;
                print("Respuesa Correcta");
            } else
            {
                vidaNave.instance.vidas--;
                print("Respuesta Incorrecta");
                MenuPausa.instance.ActualizarVidas();
            }

            controladorOperaciones.instance.generarOperacion(Random.Range(1, 3));

            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
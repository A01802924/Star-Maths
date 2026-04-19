using System.Collections;
using UnityEngine;

public class comportamientoJefe : MonoBehaviour
{
    private int vida = 10;
    private float velocidadMeteoritos = 0.4f;

    [SerializeField]
    private lanzarMeteoritos lanzaMeteoritos;

    [SerializeField]
    private controladorOperacionesJefe controlador;

    void Start()
    {
        StartCoroutine(RutinaRounds());
    }

    IEnumerator RutinaRounds()
    {
        while (true)
        {
            controlador.generarOperacion();
            controlador.MostrarInput(false);

            float tiempo = 0f;

            while (tiempo < 10f)
            {
                lanzaMeteoritos.Lanzar();
                yield return new WaitForSeconds(velocidadMeteoritos);

                tiempo += velocidadMeteoritos;
            }

            controlador.respondido = false;
            controlador.MostrarInput(true);

            tiempo = 0f;

            while (tiempo < 5f && !controlador.respondido)
            {
                yield return null;
                tiempo += Time.deltaTime;
            }

            controlador.MostrarInput(false);

            if (controlador.respondido)
            {
                if (controlador.inputRes == controlador.resultadoCorrecto)
                {
                    MenuPausa.instance.ActualizarCorrectas(10);
                }
                else
                {
                    MenuPausa.instance.ActualizarVidas();
                }
            }
            else
            {
                vidaNave.instance.vidas--;
                MenuPausa.instance.ActualizarVidas();
            }

            if (vidaNave.instance.vidas <= 0 || vida <= 0)
            {
                yield break;
            }
        }
    }

    public void Golpe()
    {
        vida--;

        if (vida <= 0)
        {
            StopAllCoroutines();
            vidaNave.instance.Ganar(10);
        }
    }
}
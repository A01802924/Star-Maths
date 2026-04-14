using Assets.Scripts.Core;
using UnityEngine;

public class DatosPartida : MonoBehaviour
{
    public static DatosPartida instance;

    public int vidas;
    public int vidasIniciales;
    public int numPreguntas;
    public int numPreguntasCorrectas;
    public int numPreguntasIncorrectas;
    public double time;


    public bool resultadoVictoria;
     

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject); //Evita que los datos se borren al cambiar de escena
    }


    public int CalcularPuntaje()
    {
        int vidasPerdidas = vidasIniciales - vidas;
        float ratio = (float)numPreguntasCorrectas / numPreguntas;

        int puntosBase = Mathf.RoundToInt(ratio * 100000);
        int penalizacion = vidasPerdidas * 500;
        int bonoTiempo = Mathf.Max(0, (int)(10000 / time));

        return puntosBase - penalizacion + bonoTiempo;
    }
    
}

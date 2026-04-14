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

    
}

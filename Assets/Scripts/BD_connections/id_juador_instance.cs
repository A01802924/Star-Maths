using UnityEngine;


public class id_juador_instance : MonoBehaviour
{
    public int id_jugador;
    public static id_juador_instance instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}


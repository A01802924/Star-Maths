using UnityEngine;

public class comportamientoJefe : MonoBehaviour
{
    private int vida = 10;

    void Start()
    {
        
    }

    public void Golpe()
    {
        vida--;

        if (vida <= 0)
        {
            vidaNave.instance.Ganar(10);
        }
        
        InvokeRepeating("Lanzar", 0f, SessionData.velocidadMeteoritos);
    }
}
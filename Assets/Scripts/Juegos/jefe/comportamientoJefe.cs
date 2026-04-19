using UnityEngine;

public class comportamientoJefe : MonoBehaviour
{
    private int vida = 10;
    [SerializeField] private lanzarMeteoritos lanzaMeteoritos;

    void Start()
    {
        InvokeRepeating("RoundLanzar", 0f, 1.5f);
    }

    public void Golpe()
    {
        vida--;

        if (vida <= 0)
        {
            vidaNave.instance.Ganar(10);
        }
    }

    private void RoundLanzar()
    {
        lanzaMeteoritos.Lanzar();
    }

    private void RoundPregunta()
    {
        
    }
}
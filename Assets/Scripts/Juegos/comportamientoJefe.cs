using UnityEngine;
using UnityEngine.SceneManagement;

public class comportamientoJefe : MonoBehaviour
{
    private int vida = 10;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Golpe()
    {
        vida--;
        if (vida <= 0)
        {
            vidaNave.instance.Ganar(10);
        }
    }
}
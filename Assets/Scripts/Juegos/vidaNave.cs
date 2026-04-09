using UnityEngine;
using UnityEngine.SceneManagement;

public class vidaNave : MonoBehaviour
{
    private int vidas = 6;
    private MostrarMenu MM;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Meteorito"))
        {
            vidas--;
            print($"Te quedan {vidas/2} vidas");
        }
        if (vidas <= 0)
        {
            Destroy(gameObject);
            MM.escenaPrevia("nose");
            SceneManager.LoadScene("MenuFinal");
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class vidaNave : MonoBehaviour
{
    public int vidas = 3;
    public int correctas = 0;

    public static vidaNave instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Meteorito"))
        {
            vidas--;
            MenuPausa.instance.ActualizarVidas();
        }
    }

    public void Perder()
    {
        Destroy(gameObject);
            SceneManager.LoadScene("MenuFinal");
    }
}
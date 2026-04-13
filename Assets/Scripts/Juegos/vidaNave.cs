using UnityEngine;
using UnityEngine.SceneManagement;

public class vidaNave : MonoBehaviour
{
    public int vidas = 3;

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
        if (vidas <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("MenuFinal");
        }
    }
}
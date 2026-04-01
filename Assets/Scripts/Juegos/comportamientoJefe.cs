using UnityEngine;
using UnityEngine.SceneManagement;

public class comportamientoJefe : MonoBehaviour
{
    private int vida = 10;
    private Animator anim;
    private SpriteRenderer sr;

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bala"))
        {
            vida--;
            Destroy(collision.gameObject);
        }
        if (vida <= 0)
        {
            Victoria();
        }
    }

    private void Victoria()
    {
        SceneManager.LoadScene("MenuFinal");
    }
}
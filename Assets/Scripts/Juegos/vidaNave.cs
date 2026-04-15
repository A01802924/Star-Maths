using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class vidaNave : MonoBehaviour
{
    public int vidas = 3;
    public int correctas = 0;

    public static vidaNave instance;

    [SerializeField] private MostrarMenu menuFinal;
    //[SerializeField] private MenuPausa menuPausa;


    void Start()
    {
        if(menuFinal == null)
        {
            menuFinal = FindAnyObjectByType<MostrarMenu>();
        }
    }

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
            //SceneManager.LoadScene("MenuFinal");
            MenuPausa.instance.respuestas.style.display = DisplayStyle.None;
            MenuPausa.instance.HUD.style.display = DisplayStyle.None;
            menuFinal.MuestraGameOver();
        }
    }
}
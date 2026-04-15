using UnityEngine;
using UnityEngine.UIElements;

public class vidaNave : MonoBehaviour
{
    public int vidas = 3;
    public int correctas = 0;

    [SerializeField]
    private GameObject creadorMeteoritos;

    public static vidaNave instance;

    private MostrarMenu menuFinal;
    // private MenuPausa menuPausa;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        if(menuFinal == null)
        {
            menuFinal = FindAnyObjectByType<MostrarMenu>();
        }
    }

    public void Perder()
    {
        Destroy(gameObject);
        Destroy(creadorMeteoritos.gameObject);
        MenuPausa.instance.respuestas.style.display = DisplayStyle.None;
        MenuPausa.instance.HUD.style.display = DisplayStyle.None;
        menuFinal.MuestraGameOver();
    }

    public void Ganar()
    {
        Destroy(gameObject);
        Destroy(creadorMeteoritos.gameObject);
        MenuPausa.instance.respuestas.style.display = DisplayStyle.None;
        MenuPausa.instance.HUD.style.display = DisplayStyle.None;
        StartCoroutine(menuFinal.MuestraMenu(30.5f, vidas, 3, 5 + (3 - vidas), 5, 3 - vidas));
    }
}
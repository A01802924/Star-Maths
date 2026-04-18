using UnityEngine;
using UnityEngine.UIElements;

public class vidaNave : MonoBehaviour
{
    public int vidas = 3;
    public int correctas = 0;

    public static vidaNave instance;

    private MostrarMenu menuFinal;

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
        MenuPausa.instance.respuestas.style.display = DisplayStyle.None;
        MenuPausa.instance.HUD.style.display = DisplayStyle.None;
        MenuPausa.instance.infoHUD.style.display = DisplayStyle.None;
        menuFinal.MuestraGameOver();
    }

    public void Ganar(int x)
    {
        Destroy(gameObject);
        MenuPausa.instance.respuestas.style.display = DisplayStyle.None;
        MenuPausa.instance.HUD.style.display = DisplayStyle.None;
        MenuPausa.instance.infoHUD.style.display = DisplayStyle.None;

        StartCoroutine(MostrarMenu.instance.MuestraMenu(30.5f, vidas, 3, x + (3 - vidas), 5, 3 - vidas));
    }
}
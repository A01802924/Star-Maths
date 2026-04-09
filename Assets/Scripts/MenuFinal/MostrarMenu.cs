using System.Collections;
using NUnit.Framework.Internal;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MostrarMenu : MonoBehaviour
{
    private UIDocument menuFinal;
    private Button repetirNivel;
    private Button menuPrincipal;
    
    private Image estrella1;
    private Image estrella2;
    private Image estrella3;
    private Image estrella1ND;
    private Image estrella2ND;
    private Image estrella3ND;
    private VisualElement menu;

    private moverNave naveController;

    //
    private Label score;
    private int totalPuntos = 150000;

    //
    private Label time;
    private int totalTiempo = 180;

    private string nombreEscena;

    void Start()
    {
        nombreEscena = "";

        menuFinal = GetComponent<UIDocument>(); 
        var root = menuFinal.rootVisualElement;
        
        //Visual Element principal que muestra todo el menu
        menu = root.Q<VisualElement>("MenuFinal");

        //Botones del menu
        repetirNivel = root.Q<Button>("Repetir");
        repetirNivel.clicked += RepetirNivel;
        menuPrincipal = root.Q<Button>("Salir");
        menuPrincipal.clicked += MenuPrincipal;

        
        //Estrellas desbloqueadas y ND (No desbloqueadas)
        estrella1 = root.Q<Image>("Estrella_1");
        estrella2 = root.Q<Image>("Estrella_2");
        estrella3 = root.Q<Image>("Estrella_3");
        estrella1ND = root.Q<Image>("Estrella_1N");
        estrella2ND = root.Q<Image>("Estrella_2N");
        estrella3ND = root.Q<Image>("Estrella_3N");

        //Label de Puntuacion y Tiempo
        score = root.Q<Label>("Score");
        time = root.Q<Label>("Time");
    
        //Ocultamos menu al inicio
        menu.style.display = DisplayStyle.None;

        naveController = FindAnyObjectByType<moverNave>();

        //Muestra el menu tras 5 segundos
        StartCoroutine(MuestraMenu());     
    }

    public void escenaPrevia(string name)
    {
        nombreEscena = name;
    }

    private IEnumerator MuestraMenu()
    {
        menu.style.display = DisplayStyle.Flex;

        if(naveController != null)
        {
            naveController.enabled = false;
        }

        //Se hace la animación en orden
        yield return StartCoroutine(AnimarScore(0, totalPuntos, 2f));
        yield return StartCoroutine(AnimarTime(0, totalTiempo, 2f));
        yield return StartCoroutine(MostrarEstrellas(totalPuntos));
    }

    private IEnumerator AnimarScore(int inicio, int fin, float duracion)
    {
        float tiempo = 0f;
        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            float progreso = tiempo /duracion;
            int valorActual = Mathf.RoundToInt(Mathf.Lerp(inicio, fin, progreso));
            score.text = "Puntuación: " + valorActual;
            yield return null;
        }
        score.text = "Puntuación: " + fin;
    }

    private IEnumerator AnimarTime(int inicio, int fin, float duracion)
    {
        float tiempo = 0f;
        while(tiempo < duracion)
        {
            tiempo +=Time.deltaTime;
            float progreso = tiempo / duracion;
            int valorActual = Mathf.RoundToInt(Mathf.Lerp(inicio, fin, progreso));
            time.text = "Tiempo: " + valorActual;
            yield return null;
        }
        time.text = "Tiempo: " + fin;
    }

    private IEnumerator MostrarEstrellas(int puntos)
    {
        //Muestra todas las etrellas nos desbloqueadas
        estrella1ND.style.display = DisplayStyle.Flex;
        estrella2ND.style.display = DisplayStyle.Flex;
        estrella3ND.style.display = DisplayStyle.Flex;

        //Asegura que no se muestren las estrellas
        estrella1.style.display = DisplayStyle.None;
        estrella2.style.display = DisplayStyle.None;
        estrella3.style.display = DisplayStyle.None;

        if(puntos >= 50)
        {
            estrella1.style.display = DisplayStyle.Flex;
            estrella1ND.style.display = DisplayStyle.None;
            yield return new WaitForSeconds(0.4f);
        }
        if(puntos >= 100)
        {
            estrella2ND.style.display = DisplayStyle.None;
            estrella2.style.display = DisplayStyle.Flex;
            yield return new WaitForSeconds(0.4f);
        }
        if(puntos >= 150)
        {
            estrella3ND.style.display = DisplayStyle.None;
            estrella3.style.display = DisplayStyle.Flex;
            yield return new WaitForSeconds(0.4f);
        }
    }

    private void RepetirNivel()
    {
        SceneManager.LoadScene(nombreEscena);
    }

    private void MenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipalScene");
    }
}
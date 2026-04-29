using System.Collections;
using Assets.Scripts.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MostrarMenu : MonoBehaviour
{
    public static MostrarMenu instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

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

    private Label score;
    [SerializeField]
    private int totalPuntos = 0;
    public int TotalPuntos => totalPuntos;

    private Label time;
    [SerializeField]
    private float totalTiempo = 0;
    public float TotalTiempo => totalTiempo;

    private VisualElement contenedorMenu;
    private Button resumen;
    private VisualElement contenedorResumen;
    private Label vidas;
    private Label preguntas;
    private Label preguntasCorrecto;
    private Label preguntasIncorrecto;
    private Button cerrarStats;
    private Label cantidadMonedas;
    private int vidasRes;
    private int vidasI;
    [SerializeField]
    private int preguntasT = 0;
    public int PreguntasT => preguntasT;
    [SerializeField]
    private int preguntasC = 0;
    public int PreguntasC => preguntasC;
    private int preguntasI = 0;
    private int monedas = 0;
    private bool llamadoBD = false;

    private VisualElement menuParInf;
    private VisualElement menuGameOver;
    private Label victoria;
    private Button reiniciarGO;
    private Button menuPrincipalGO;


    void Start()
    {
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

        //Elementos añadidos en la última versión
        contenedorMenu = root.Q<VisualElement>("ContenedorMenu");
        resumen = root.Q<Button>("Resumen");
        resumen.RegisterCallback<ClickEvent>(evt => MostrarResumen(vidasRes, preguntasT, preguntasC, preguntasI, totalTiempo));

        contenedorResumen = root.Q<VisualElement>("ContenedorResumen");
        vidas = root.Q<Label>("Vidas");
        preguntas = root.Q<Label>("Preguntas");
        preguntasCorrecto = root.Q<Label>("Correcto");
        preguntasIncorrecto = root.Q<Label>("Incorrecto");
        cantidadMonedas = root.Q<Label>("Monedas");
        cerrarStats = root.Q<Button>("CerrarStats");
        cerrarStats.clicked += CerrarStats;

        menuParInf = root.Q<VisualElement>("Menu");
        menuGameOver = root.Q<VisualElement>("MenuGameOver");
        victoria = root.Q<Label>("Victoria");
        reiniciarGO = root.Q<Button>("RepetirGO");
        reiniciarGO.clicked += RepetirNivel;
        menuPrincipalGO = root.Q<Button>("SalirGO");
        menuPrincipalGO.clicked += MenuPrincipal;

        menuGameOver.style.display = DisplayStyle.None;
    }

    private void CerrarStats()
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickClosePopUPDialog);
        contenedorResumen.style.display = DisplayStyle.None;
        contenedorMenu.style.display = DisplayStyle.Flex;
    }

    private void MostrarResumen(int vidasRestantes, int totalPreguntas, int resCorrectas, int resIncorrectas, float tiempo)
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickNewTab);
        contenedorMenu.style.display = DisplayStyle.None;
        contenedorResumen.style.display = DisplayStyle.Flex;

        vidas.text = "VIDAS RESTANTES:     " + vidasRestantes.ToString();
        preguntas.text = "TOTAL DE PREGUNTAS:     " + totalPreguntas.ToString();
        preguntasCorrecto.text = "RESPUESTAS CORRECTAS:     " + resCorrectas.ToString();
        preguntasIncorrecto.text = "RESPUESTAS INCORRECTAS:     " + resIncorrectas.ToString();
        cantidadMonedas.text = "MONEDAS:     " + monedas.ToString();

    }

    public IEnumerator MuestraMenu(float tiempo, int vidasRestantes, int vidasIniciales, int totalPreguntas, int resCorrectas, int resIncorrectas)
    {
        totalTiempo = tiempo;
        vidasRes = vidasRestantes;
        vidasI = vidasIniciales;

        preguntasT = totalPreguntas;
        preguntasC = resCorrectas;
        preguntasI = resIncorrectas;

        totalPuntos = CalcularPuntaje(vidasRes, vidasIniciales, preguntasT, preguntasC, totalTiempo);

        menu.style.display = DisplayStyle.Flex;
        menuParInf.style.display = DisplayStyle.Flex;
        contenedorMenu.style.display = DisplayStyle.Flex;

        if (naveController != null)
        {
            naveController.enabled = false;
        }

        //Se hace la animación en orden
        yield return StartCoroutine(AnimarScore(0, totalPuntos, 2f));
        // yield return StartCoroutine(AnimarTime(0, totalTiempo, 2f));
        // yield return StartCoroutine(MostrarEstrellas(preguntasT, preguntasC));
    }

    public void MuestraGameOver()
    {
        menu.style.display = DisplayStyle.Flex;
        menuGameOver.style.display = DisplayStyle.Flex;
        victoria.style.display = DisplayStyle.None;
        if (!llamadoBD)
        {
            llamadoBD = true;
            PuntajeBD.instance.Guardar(false, vidasRes);
        }//aqui es para la base
    }



    private IEnumerator AnimarScore(int inicio, int fin, float duracion)
    {
        float tiempo = 0f;
        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            float progreso = tiempo / duracion;
            int valorActual = Mathf.RoundToInt(Mathf.Lerp(inicio, fin, progreso));
            score.text = "PUNTUACIÓN:      " + valorActual;
            yield return null;
        }
        score.text = "PUNTUACIÓN:     " + fin;
        StartCoroutine(AnimarTime(0, totalTiempo, 2f));
    }

    private IEnumerator AnimarTime(int inicio, float fin, float duracion)
    {
        float tiempo = 0f;
        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            float progreso = tiempo / duracion;
            int valorActual = Mathf.RoundToInt(Mathf.Lerp(inicio, fin, progreso));
            time.text = "TIEMPO:      " + valorActual;
            yield return null;
        }
        time.text = "TIEMPO:      " + fin;
        StartCoroutine(MostrarEstrellas(vidasRes));
    }

    private IEnumerator MostrarEstrellas(int vidasRes)
    {
        //Muestra todas las etrellas nos desbloqueadas
        estrella1ND.style.display = DisplayStyle.Flex;
        estrella2ND.style.display = DisplayStyle.Flex;
        estrella3ND.style.display = DisplayStyle.Flex;

        //Asegura que no se muestren las estrellas
        estrella1.style.display = DisplayStyle.None;
        estrella2.style.display = DisplayStyle.None;
        estrella3.style.display = DisplayStyle.None;

        if (vidasRes >= 1)
        {
            monedas = 100;
            estrella1.style.display = DisplayStyle.Flex;
            estrella1ND.style.display = DisplayStyle.None;
            yield return new WaitForSeconds(0.4f);
            AudioManager.Instance.PlayUISFX(AudioClipSet.ClickResetChanges);
        }
        if (vidasRes >= 2)
        {
            monedas = 200;
            estrella2ND.style.display = DisplayStyle.None;
            estrella2.style.display = DisplayStyle.Flex;
            yield return new WaitForSeconds(0.4f);
            AudioManager.Instance.PlayUISFX(AudioClipSet.ClickResetChanges);
        }
        if (vidasRes >= 3)
        {
            monedas = 300;
            estrella3ND.style.display = DisplayStyle.None;
            estrella3.style.display = DisplayStyle.Flex;
            yield return new WaitForSeconds(0.4f);
            AudioManager.Instance.PlayUISFX(AudioClipSet.ClickSaveChanges);
        }
        if (!llamadoBD)
        {
            llamadoBD = true;
            PuntajeBD.instance.Guardar(true, vidasRes);
        }//aqui es para la base 
    }



    private void RepetirNivel()
    {
        //SceneManager.LoadScene(nombreEscena);
        // TODO: handle different AudioClip source per game type
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickNewTab);
        AudioManager.Instance.SetTrackStartTime(0f);
        if (SessionData.JuegoJefe)
        {
            AudioManager.Instance.PlayNewTrack(AudioClipSet.BossGameBackgroundMusic);
        }
        else
        {
            AudioManager.Instance.PlayNewTrack(AudioClipSet.LevelGameBackgroundMusic);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void MenuPrincipal()
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickNewTab);
        AudioManager.Instance.SetTrackStartTime(0f);
        AudioManager.Instance.PlayNewTrack(AudioClipSet.MainBackgroundMusic);
        SceneManager.LoadScene("MenuPrincipalScene");
    }

    public int CalcularPuntaje(int vi, int vr, int np, int npc, float t)
    {
        int vidasPerdidas = vi - vr;
        float ratio = (float)npc / np;

        int puntosBase = Mathf.RoundToInt(ratio * 100000);
        int penalizacion = vidasPerdidas * 5000;
        int bonoTiempo = Mathf.Max(0, (int)(10000 / t));

        return puntosBase - penalizacion + bonoTiempo;
    }

}
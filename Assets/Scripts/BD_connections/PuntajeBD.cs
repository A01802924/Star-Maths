using System.Collections;
using Assets.Scripts.Core;
using UnityEngine;
using UnityEngine.Networking;

public class PuntajeBD : MonoBehaviour
{
    private MostrarMenu menu;
    public static PuntajeBD instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        menu = GetComponent<MostrarMenu>();
    }


    public struct MandarDatos
    {
        public int puntaje;
        public int duracion;
        public bool victoria;
        public int estrellas;
        public float precision;
        public int id_jugador;
        public int id_mundo;
        public int nivel;
    }

    public void Guardar(bool victoria, int estrellas)
    {
              
        print ("Guardando puntaje...");
        SessionData.Victoria = victoria;
        StartCoroutine(EnviarDatos(estrellas));
    }

    private IEnumerator EnviarDatos(int estrellas)
    {
        int puntaje = menu.TotalPuntos;
        float tiempo = menu.TotalTiempo;

        int preguntasT = menu.PreguntasT;
        int preguntasC = menu.PreguntasC;

        float precision = (preguntasT == 0) ? 0 : ((float)preguntasC / preguntasT) * 100f;



        MandarDatos data = new MandarDatos
        {
            puntaje = puntaje,
            duracion = Mathf.RoundToInt(tiempo),
            victoria = SessionData.Victoria,
            estrellas = estrellas,
            precision = precision,
            id_jugador = id_juador_instance.instance.id_jugador,
            id_mundo = SessionData.SelectedWorldID,
            nivel = SessionData.SelectedLevelID
        };
         if (SessionData.JuegoJefe)
        {
            data.id_mundo = 6;
            data.nivel = 5;
        }


        string json = JsonUtility.ToJson(data);

        UnityWebRequest request = UnityWebRequest.Post("https://ejqqvbkeso7awheffaw6brvsdi0prujw.lambda-url.us-east-1.on.aws/puntaje", json, "application/json"
        );

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            print("Respuesta: " + request.downloadHandler.text);;
        }
        else
        {
            Debug.LogError("Error: " + request.downloadHandler.text);
        }
    }
}

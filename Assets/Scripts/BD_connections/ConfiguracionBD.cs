using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Assets.Scripts.Core;
using Unity.VisualScripting;

public class ConfiguracionBD : MonoBehaviour
{

    public struct MandarDatos
    {
        public int vol_efectos;
        public int vol_musica;
        public int brillo;
        public int id_jugador;
    }
public class RegresarDatos
    {
        public bool exito;
        public string aviso;
        public MandarDatos configuracion;
    }

    [System.Serializable]
public class GetMandarDatos
{
    public int vol_efectos;
    public int vol_musica;
    public int brillo;
    public int id_jugador;
}

[System.Serializable]
public class GetRegresarDatos
{
    public bool exito;
    public string aviso;
    public GetMandarDatos configuracion; 
}

    public void CargarConfiguracion()
{
    StartCoroutine(ObtenerConfiguracion()); //get
}


    public void GuardarConfiguracion()
    {
        print("Guardando configuracion...");
        StartCoroutine(EnviarDatos()); //post 
    }

    private IEnumerator EnviarDatos() //post
    {
        int vol_efectos = Mathf.RoundToInt(SessionData.SFXVolumen);
        int vol_musica = Mathf.RoundToInt(SessionData.MusicVolumen);
        int brillo = Mathf.RoundToInt(SessionData.ScreenBrightness);

        GetMandarDatos data = new GetMandarDatos
        {
            vol_efectos = vol_efectos,
            vol_musica = vol_musica,
            brillo = brillo,
            id_jugador = id_juador_instance.instance.id_jugador
        };

        string json = JsonUtility.ToJson(data);

        UnityWebRequest request = UnityWebRequest.Post("https://ejqqvbkeso7awheffaw6brvsdi0prujw.lambda-url.us-east-1.on.aws/configuracion", json, "application/json"); 


        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            print("Respuesta: " + request.downloadHandler.text);

            RegresarDatos r = JsonUtility.FromJson<RegresarDatos>(request.downloadHandler.text);

            if (r.exito)
            {
                Debug.Log("Configuración guardada exitosamente");
                StartCoroutine(ObtenerConfiguracion()); //get para actualizar la configuración después de guardarla
            }
            else
            {
                Debug.LogError("Error: " + r.aviso);
            }
        }
        else
        {
            Debug.LogError("Error de red: " + request.error);
        }
    }

    public IEnumerator ObtenerConfiguracion() //get
{
    int id = id_juador_instance.instance.id_jugador;
    UnityWebRequest request = UnityWebRequest.Get("https://ejqqvbkeso7awheffaw6brvsdi0prujw.lambda-url.us-east-1.on.aws/configuracion/"+id); 
    Debug.Log("Obteniendo configuración para id_jugador: " + id);

        yield return request.SendWebRequest();

    if (request.result == UnityWebRequest.Result.Success)
    {
        var json = request.downloadHandler.text;

        GetRegresarDatos r = JsonUtility.FromJson<GetRegresarDatos>(json);

        if (r.exito)
        {
            Debug.Log ("Configuración obtenida: " + json);
            SessionData.SFXVolumen = r.configuracion.vol_efectos;
            SessionData.MusicVolumen = r.configuracion.vol_musica;
            SessionData.ScreenBrightness = r.configuracion.brillo;

            Debug.Log ("Configuración aplicada: Brillo=" + SessionData.ScreenBrightness + ", Volumen Música=" + SessionData.MusicVolumen + ", Volumen Efectos=" + SessionData.SFXVolumen);
            AplicarConfiguracion();
            Debug.Log("Configuración cargada exitosamente: " + json);
        }
    }
    else
    {
        Debug.LogError("Error GET config: " + request.error);
    }
}
    private void AplicarConfiguracion() //aplica la configuración obtenida de la base de datos a las preferencias del juego
    {
        Debug.Log ("Aplicando configuración: Brillo=" + SessionData.ScreenBrightness + ", Volumen Música=" + SessionData.MusicVolumen + ", Volumen Efectos=" + SessionData.SFXVolumen);
        AudioClipSet.MusicVolume(SessionData.MusicVolumen);
        AudioClipSet.SFXVolume(SessionData.SFXVolumen);

        ConfigurationPreferences.DarkScreenLayer.style.opacity = 0.0085f * (100 - SessionData.ScreenBrightness);
}
}


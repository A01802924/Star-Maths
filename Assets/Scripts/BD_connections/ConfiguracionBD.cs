using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Assets.Scripts.Core;
using Unity.VisualScripting;

public class ConfiguracionBD : MonoBehaviour
{

    [System.Serializable]
    public struct MandarDatos
    {
        public int vol_efectos;
        public int vol_musica;
        public int brillo;
        public int id_jugador;
    }

    public struct MandarMensaje
    {
        public int vol_efectos;
        public int vol_musica;
        public int brillo;
    }

    [System.Serializable]
    public class RegresarDatos
    {
        public bool exito;
        public string aviso;
        public MandarMensaje configuracion;
    }
    public void CargarConfiguracion()
{
    StartCoroutine(ObtenerConfiguracion());
}


    public void GuardarConfiguracion()
    {
        print("Guardando configuracion...");
        StartCoroutine(EnviarDatos());
    }

    private IEnumerator EnviarDatos()
    {
        int vol_efectos = Mathf.RoundToInt(SessionData.SFXVolumen);
        int vol_musica = Mathf.RoundToInt(SessionData.MusicVolumen);
        int brillo = Mathf.RoundToInt(SessionData.ScreenBrightness);

        MandarDatos data = new MandarDatos
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

    public IEnumerator ObtenerConfiguracion()
{
    int id = id_juador_instance.instance.id_jugador;
    UnityWebRequest request = UnityWebRequest.Get("https://ejqqvbkeso7awheffaw6brvsdi0prujw.lambda-url.us-east-1.on.aws/configuracion/"+id); 


        yield return request.SendWebRequest();

    if (request.result == UnityWebRequest.Result.Success)
    {
        var json = request.downloadHandler.text;

        RegresarDatos r = JsonUtility.FromJson<RegresarDatos>(json);

        if (r.exito)
        {
            SessionData.SFXVolumen = r.configuracion.vol_efectos;
            SessionData.MusicVolumen = r.configuracion.vol_musica;
            SessionData.ScreenBrightness = r.configuracion.brillo;

            AplicarConfiguracion();
        }
    }
    else
    {
        Debug.LogError("Error GET config: " + request.error);
    }
}
    private void AplicarConfiguracion()
    {
        AudioClipSet.MusicVolume(SessionData.MusicVolumen);
        AudioClipSet.SFXVolume(SessionData.SFXVolumen);

        ConfigurationPreferences.DarkScreenLayer.style.opacity =
        0.0085f * (100 - SessionData.ScreenBrightness);
}
}


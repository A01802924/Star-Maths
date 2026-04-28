using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Assets.Scripts.Core;

public class CustomizeBD : MonoBehaviour
{
     public struct MandarDatos
    {
        public int id_jugador;
        public int id_item;
    }
public class RegresarDatos
    {
        public bool exito;
        public string aviso;
    }

    public void SeleccionarItem(int idJugador, int idItem)
    {
        StartCoroutine(EnviarSeleccion(idJugador, idItem));
    }

public void ComprarItem(int idJugador, int idItem)
    {
        StartCoroutine(EnviarSeleccion(idJugador, idItem));
    }

    private IEnumerator EnviarSeleccion(int idJugador, int idItem)
    {
        Debug.Log("Enviando selección a la base de datos: Jugador ID = " + idJugador + ", Item ID = " + idItem);
        MandarDatos data = new MandarDatos
        {
            id_jugador = idJugador,
            id_item = idItem
        };

        string json = JsonUtility.ToJson(data);

        UnityWebRequest request = UnityWebRequest.Post("https://ejqqvbkeso7awheffaw6brvsdi0prujw.lambda-url.us-east-1.on.aws/customize", json, "application/json"); 


        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            print("Respuesta: " + request.downloadHandler.text);

            RegresarDatos r = JsonUtility.FromJson<RegresarDatos>(request.downloadHandler.text);

            if (r.exito)
            {
                Debug.Log("Seleccion guardada exitosamente");
                ActualizarSeleccionLocal(idItem);
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
    private void ActualizarSeleccionLocal(int idItem)
    {
        Item item = BuscarItemPorID(idItem);

        if (item == null) return;
            switch (item.tipo)
        {
            case "S":
             SessionData.CurrentShipItem = item;
            break;

            case "P":
            SessionData.CurrentProjectileItem = item;
            break;

            case "T":
            SessionData.CurrentTrailItem = item;
            break;
}
    }

    private Item BuscarItemPorID(int id)
    {
        foreach (var item in ItemSet.ShipItems)
            if (item.index == id) return item;

        foreach (var item in ItemSet.ProjectileItems)
            if (item.index == id) return item;

        foreach (var item in ItemSet.TrailItems)
            if (item.index == id) return item;

        return null;
    }
}

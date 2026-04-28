using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Assets.Scripts.Core;
using System.Collections.Generic;

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
    [System.Serializable]
public class SelectedItemDatos
{
    public int id_item;
}

[System.Serializable]
public class GetSelectedItemsResponse
{
    public bool exito;
    public string aviso;
    public List<SelectedItemDatos> items;
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
             Debug.Log("Item seleccionado aplicado: " + SessionData.CurrentShipItem.name + " ID: " + SessionData.CurrentShipItem.index + ")");
            break;

            case "P":
            SessionData.CurrentProjectileItem = item;
            Debug.Log("Item seleccionado aplicado: " + SessionData.CurrentProjectileItem.name + " ID: " + SessionData.CurrentProjectileItem.index + ")");
            break;

            case "T":
            SessionData.CurrentTrailItem = item;
            Debug.Log("Item seleccionado aplicado: " + SessionData.CurrentTrailItem.name + " ID: " + SessionData.CurrentTrailItem.index + ")");
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

    public IEnumerator ObtenerSelectedItems(System.Action callback)
{
    int id = id_juador_instance.instance.id_jugador;

    Debug.Log("Obteniendo items seleccionados para jugador: " + id);

    UnityWebRequest request = UnityWebRequest.Get( "https://ejqqvbkeso7awheffaw6brvsdi0prujw.lambda-url.us-east-1.on.aws/customize/" + id);

    yield return request.SendWebRequest();

    if (request.result == UnityWebRequest.Result.Success)
    {
        string json = request.downloadHandler.text;

        Debug.Log("Respuesta selected items: " + json);

        GetSelectedItemsResponse r = JsonUtility.FromJson<GetSelectedItemsResponse>(json);

        if (r.exito)
        {
            AplicarSelectedItems(r);
            callback?.Invoke();
        }
        else
        {
            Debug.LogError("Error: " + r.aviso);
        }
    }
    else
    {
        Debug.LogError("Error GET selected items: " + request.error);
    }
}

private void AplicarSelectedItems(GetSelectedItemsResponse data)
{
    foreach (var itemData in data.items)
    {
        Item item = BuscarItemPorID(itemData.id_item);

        if (item == null) continue;

        switch (item.tipo)
        {
            case "S":
                SessionData.CurrentShipItem = item;
               Debug.Log("Item seleccionado aplicado: " + SessionData.CurrentShipItem.name + " ID: " + SessionData.CurrentShipItem.index + ")");
                break;

            case "P":
                SessionData.CurrentProjectileItem = item;
                Debug.Log("Item seleccionado aplicado: " + SessionData.CurrentProjectileItem.name + " ID: " + SessionData.CurrentProjectileItem.index + ")");
                break;

            case "T":
                SessionData.CurrentTrailItem = item;
                Debug.Log("Item seleccionado aplicado: " + SessionData.CurrentTrailItem.name + " ID: " + SessionData.CurrentTrailItem.index + ")");
                break;
        }
    }

    Debug.Log("Items seleccionados aplicados correctamente");
}
}

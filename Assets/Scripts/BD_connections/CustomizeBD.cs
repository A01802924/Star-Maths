using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Assets.Scripts.Core;
using System.Collections.Generic;

public class CustomizeBD : MonoBehaviour
{
    [System.Serializable]
public class MandarTodo
{
    public int id_jugador;
    public int ship;
    public int projectile;
    public int trail;
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


public void GuardarTodo()
{
    StartCoroutine(EnviarTodo());
}

private IEnumerator EnviarTodo()
{
    MandarTodo data = new MandarTodo
    {
        id_jugador = id_juador_instance.instance.id_jugador,


        ship = SessionData.CurrentShipItem.index,
        projectile = SessionData.CurrentProjectileItem.index,
        trail = SessionData.CurrentTrailItem.index
    };

    string json = JsonUtility.ToJson(data);

    UnityWebRequest request = UnityWebRequest.Post("https://ejqqvbkeso7awheffaw6brvsdi0prujw.lambda-url.us-east-1.on.aws/customize", json, "application/json");

    yield return request.SendWebRequest();

    if (request.result == UnityWebRequest.Result.Success)
    {
        Debug.Log("Todo guardado correctamente");
    }
    else
    {
        Debug.LogError("Error: " + request.error);
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

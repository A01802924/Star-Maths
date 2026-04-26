using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Assets.Scripts.Core;
using System.Collections.Generic;
using Unity.VisualScripting;

public class TiendaBD : MonoBehaviour
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
public class ItemDatos
{
    public int id_item;
}

[System.Serializable]
public class GetRegresarDatos
{
    public bool exito;
    public string aviso;
    public int monedas;
    public List<ItemDatos> items;
}

    public void ComprarItem(int idJugador, int idItem)
    {
        StartCoroutine(EnviarCompra(idJugador, idItem));
    }

    private IEnumerator EnviarCompra(int idJugador, int idItem)
    {
        Debug.Log("Enviando compra a la base de datos: Jugador ID = " + idJugador + ", Item ID = " + idItem);
        MandarDatos data = new MandarDatos
        {
            id_jugador = idJugador,
            id_item = idItem
        };

        string json = JsonUtility.ToJson(data);

        UnityWebRequest request = UnityWebRequest.Post("https://ejqqvbkeso7awheffaw6brvsdi0prujw.lambda-url.us-east-1.on.aws/tienda", json, "application/json"); 


        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            print("Respuesta: " + request.downloadHandler.text);

            RegresarDatos r = JsonUtility.FromJson<RegresarDatos>(request.downloadHandler.text);

            if (r.exito)
            {
                Debug.Log("Compra guardada exitosamente");
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
    public IEnumerator ObtenerTienda(System.Action callback)
{
    int id = id_juador_instance.instance.id_jugador;

    Debug.Log("Obteniendo tienda para el jugador con ID: " + id);

    UnityWebRequest request = UnityWebRequest.Get( "https://ejqqvbkeso7awheffaw6brvsdi0prujw.lambda-url.us-east-1.on.aws/tienda/" + id);

    yield return request.SendWebRequest();

    if (request.result == UnityWebRequest.Result.Success)
    {
        var json = request.downloadHandler.text;
        
            Debug.Log("Respuesta de la tienda: " + json);

        GetRegresarDatos r = JsonUtility.FromJson<GetRegresarDatos>(json);

        if (r.exito)
    {
        AplicarTienda(r);
        Debug.Log("Tienda cargada: " + json);

        callback?.Invoke();
    }
}
else
{
    Debug.LogError("Error GET tienda: " + request.error);
}
}

    private void AplicarTienda(GetRegresarDatos data)
{
    SessionData.coins = data.monedas;


    SessionData.OwnedItems.Clear();

    foreach (var itemData in data.items)
    {
        Item item = BuscarItemPorID(itemData.id_item);

        if (item != null)
        {
            SessionData.OwnedItems.Add(item);
        }
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

using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

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
}

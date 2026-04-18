using Assets.Scripts.Core;
using UnityEngine;

public class crearMeteoritos : MonoBehaviour
{
    [SerializeField]
    private GameObject meteoritos;

    void Start()
    {
        //InvokeRepeating("Crear", 0f, SessionData.velocidadMeteoritos);
        InvokeRepeating("Crear", 0f, 3f);
    }

    void Crear()
    {
        Instantiate(meteoritos, transform.position, transform.rotation);
    }
}
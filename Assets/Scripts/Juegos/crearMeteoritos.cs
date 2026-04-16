using Assets.Scripts.Core;
using UnityEngine;

public class crearMeteoritos : MonoBehaviour
{
    [SerializeField]
    private GameObject meteoritos;

    void Start()
    {
        InvokeRepeating("Crear", 0f, SessionData.velocidadMeteoritos);
    }

    void Crear()
    {
        Instantiate(meteoritos, transform.position, transform.rotation);
    }
}
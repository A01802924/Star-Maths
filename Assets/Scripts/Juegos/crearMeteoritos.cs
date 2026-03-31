using UnityEngine;
using System.Collections;

public class crearMeteoritos : MonoBehaviour
{
    [SerializeField]
    private GameObject meteoritos;

    void Start()
    {
        StartCoroutine(creacionMeteoritos());
    }

    IEnumerator creacionMeteoritos()
    {
        while (true)
        {
            Crear();
            yield return new WaitForSeconds(5f);
        }
    }

    void Crear()
    {
        Instantiate(meteoritos, transform.position, transform.rotation);
    }
}
using UnityEngine;
using System.Collections.Generic;

public class lanzarMeteoritos : MonoBehaviour
{
    private int num;
    [SerializeField] private List<GameObject> meteoritos = new List<GameObject>();

    public void Lanzar()
    {
        num = Random.Range(0, 3);
        Instantiate(meteoritos[num], transform.position, transform.rotation);
    }
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Core;

public class lanzarMeteoritos : MonoBehaviour
{
    private int num;
    [SerializeField]
    private GameObject m1;
    [SerializeField]
    private GameObject m2;
    [SerializeField]
    private GameObject m3;
    private List<GameObject> meteoritos = new List<GameObject>();

    void Start()
    {
        meteoritos.Add(m1);
        meteoritos.Add(m2);
        meteoritos.Add(m3);
        InvokeRepeating("Lanzar", 0f, SessionData.velocidadMeteoritos);
    }

    void Lanzar()
    {
        num = Random.Range(0, 3);
        Instantiate(meteoritos[num], transform.position, transform.rotation);
    }
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
        StartCoroutine(lanzaMeteoritos());
    }

    IEnumerator lanzaMeteoritos()
    {
        while (true)
        {
            Lanzar();
            yield return new WaitForSeconds(1.5f);
        }
    }

    void Lanzar()
    {
        num = Random.Range(0, 3);
        Instantiate(meteoritos[num], transform.position, transform.rotation);
    }
}
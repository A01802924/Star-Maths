using UnityEngine;

public class disparaNave : MonoBehaviour
{
    [SerializeField]
    private GameObject bala;

    public void Disparar()
    {
        Instantiate(bala, transform.position, transform.rotation);
    }
}
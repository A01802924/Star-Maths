using UnityEngine;

public class destruirSonido : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1f);
    }
}
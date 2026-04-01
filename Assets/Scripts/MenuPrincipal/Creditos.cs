using UnityEngine;
using UnityEngine.UIElements;

public class Creditos : MonoBehaviour
{
    public float speed = 150f;
    private VisualElement creditos;
    private float currentY = 0;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        creditos = root.Q<VisualElement>("Contenido");

        currentY = Screen.height;
    }

    void Update()
    {
        if(creditos != null)
        {
            currentY -= speed * Time.deltaTime;
            creditos.style.top = currentY;

            if(currentY < -creditos.layout.height * 2)
            {
                currentY = Screen.height;
            }
        }
    }


}

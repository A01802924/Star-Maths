using UnityEngine;
using UnityEngine.UIElements; // Necesario para UI Toolkit
using UnityEngine.SceneManagement;

public class ControladorUI : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button botonCambio = root.Q<Button>("Inicio");

        if (botonCambio != null)
        {
            botonCambio.clicked += OnBotonClicked;
        }
    }

    private void OnBotonClicked()
    {
        SceneManager.LoadScene("LoginScene");
    }
}
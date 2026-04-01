using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Info : MonoBehaviour
{
    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        var puntajes= root.Q<Button>("PUNTAJE");

        var tienda = root.Q<Button>("TIENDA");

        var tutoral = root.Q<Button>("TUTORIAL");



        var home = root.Q<Button>("home");

        puntajes.RegisterCallback<ClickEvent>(AbrirPuntajes);
        void AbrirPuntajes(ClickEvent evt)
        {
            SceneManager.LoadScene("Puntuacion");
        }

        tienda.RegisterCallback<ClickEvent>(AbrirTienda);
        void AbrirTienda(ClickEvent evt)
        {
            SceneManager.LoadScene("Personalizar");
        }

        tutoral.RegisterCallback<ClickEvent>(AbrirTutorial);
        void AbrirTutorial(ClickEvent evt)
        {
            SceneManager.LoadScene("Tutorial");
        }

        home.RegisterCallback<ClickEvent>(AbrirHome);
        void AbrirHome(ClickEvent evt)
        {
            SceneManager.LoadScene("MenuPrincipalScene");
        }
    }
}


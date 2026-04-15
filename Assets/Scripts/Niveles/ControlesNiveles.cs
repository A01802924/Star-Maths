using Assets.Scripts.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ControlesNiveles : MonoBehaviour
{
    private Button nivel1;
    private Button nivel2;
    private Button nivel3;
    private Button nivel4;
    private Button info;
    private Button home;
    private Button regresar;


    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        nivel1 = root.Q<Button>("1");
        nivel2 = root.Q<Button>("2");
        nivel3 = root.Q<Button>("3");
        nivel4 = root.Q<Button>("4");

        info = root.Q<Button>("info");
        regresar = root.Q<Button>("regresar");
        home = root.Q<Button>("home");

        nivel1.clicked += () => MostrarGameplay(1);
        nivel2.clicked += () => MostrarGameplay(2);
        nivel3.clicked += () => MostrarGameplay(3);
        nivel4.clicked += () => MostrarGameplay(4);

        info.clicked += MostrarInfo;
        regresar.clicked += Regresar;
        home.clicked += VolverMenuPrincipal;
    }

    private void MostrarGameplay(int levelIndex)
    {
        SessionData.SelectedLevelID = levelIndex;
        SceneManager.LoadScene("JuegoMeteoritos");
    }

    private void MostrarInfo()
    {
        SceneManager.LoadScene("Informacion");
    }

    private void Regresar()
    {
        SceneManager.LoadScene("Mundos");
    }

    private void VolverMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipalScene");
    }


}

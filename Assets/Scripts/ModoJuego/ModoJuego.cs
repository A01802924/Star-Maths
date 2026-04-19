using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Assets.Scripts.Core;

public class ModoJuego : MonoBehaviour
{
    private UIDocument UIDocument;
    private Button btnInfo2;
    private Button btnHome;
    private Button regresar;
    private Button btnGranEnemigo;
    private Button btnEsquiva;
    void OnEnable()
    {
        UIDocument = GetComponent<UIDocument>();
        var root = UIDocument.rootVisualElement;

        root.Add(ConfigurationPreferences.DarkScreenLayer);

        btnInfo2 = root.Q<Button>("Info2");
        btnHome = root.Q<Button>("Home");
        regresar = root.Q<Button>("RegresarMenu");
        btnGranEnemigo = root.Q<Button>("GranEnemigo");
        btnEsquiva = root.Q<Button>("EsqujvaMeteoritos");

        btnInfo2.RegisterCallback<ClickEvent>(OnInfoClicked);
        btnHome.RegisterCallback<ClickEvent>(OnHomeClicked);
        regresar.RegisterCallback<ClickEvent>(OnHomeClicked);
        btnGranEnemigo.RegisterCallback<ClickEvent>(OnGranEnemigoClicked);
        btnEsquiva.RegisterCallback<ClickEvent>(OnEsquivaClicked);

    }
    private void OnEsquivaClicked(ClickEvent evt)
    {
        SessionData.JuegoJefe = false;//aqui es para la base
        print("juego jefe: " + SessionData.JuegoJefe); 
        SceneManager.LoadScene("Mundos");
    }
    private void OnGranEnemigoClicked(ClickEvent evt)
    {
        SessionData.JuegoJefe = true;//aqui es para la base
        print("juego jefe: " + SessionData.JuegoJefe); 
        SceneManager.LoadScene("JuegoJefe");
    }
    private void OnHomeClicked(ClickEvent evt)
    {
        SceneManager.LoadScene("MenuPrincipalScene");
    }

    private void OnInfoClicked(ClickEvent evt)
    {
        SceneManager.LoadScene("Informacion");
    }
}

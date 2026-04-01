using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ModoJuego : MonoBehaviour
{
    private UIDocument UIDocument;
    private Button btnInfo2;
    private Button btnHome;
    private Button regresar;
    void OnEnable()
    {
        UIDocument = GetComponent<UIDocument>();
        var root = UIDocument.rootVisualElement;

        btnInfo2 = root.Q<Button>("Info2");
        btnHome = root.Q<Button>("Home");
        regresar = root.Q<Button>("RegresarMenu");

        btnInfo2.RegisterCallback<ClickEvent>(OnInfoClicked);
        btnHome.RegisterCallback<ClickEvent>(OnHomeClicked);
        regresar.RegisterCallback<ClickEvent>(OnHomeClicked);

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

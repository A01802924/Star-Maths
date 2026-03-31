using UnityEngine;
using UnityEngine.UIElements;

public class CerrarJuego : MonoBehaviour
{
    private UIDocument scene;
    private Button cerrar;



    void OnEnable()
    {
        scene = GetComponent<UIDocument>();
        var root = scene.rootVisualElement;

        cerrar = root.Q<Button>("Cerrar");
        cerrar.clicked += CierreJuego;
    }

    private void CierreJuego()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}

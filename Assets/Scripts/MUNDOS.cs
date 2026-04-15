using Assets.Scripts.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MUNDOS : MonoBehaviour
{
void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        var earth = root.Q<Button>("EARTH");
        var suma = root.Q<Button>("SUMA");

        var neptune = root.Q<Button>("NEPTUNE");
        var resta = root.Q<Button>("RESTA");
        
        var uranus = root.Q<Button>("URANUS");
        var multiplicacion = root.Q<Button>("MULTIPLICACION");
        
        var pluto = root.Q<Button>("PLUTO");
        var division = root.Q<Button>("DIVISION");

        var moon = root.Q<Button>("MOON");
        var union = root.Q<Button>("UNION");

        var info= root.Q<Button>("info");

        var home = root.Q<Button>("home");

        var regresar = root.Q<Button>("regresar");

        var confi = root.Q<Button>("Configuracion");


        earth.RegisterCallback<MouseEnterEvent>(evt =>
        {
            suma.AddToClassList("OBSCURO");
        });

        earth.RegisterCallback<MouseLeaveEvent>(evt =>
        {
            suma.RemoveFromClassList("OBSCURO");
        });

        earth.RegisterCallback<ClickEvent>(evt => {
            AbrirNiveles(evt);
            SessionData.SelectedWorldID = 1;
            print("Selected world: Addition");
        });
        

        neptune.RegisterCallback<MouseEnterEvent>(evt =>
        {
            resta.AddToClassList("OBSCURO");
        });

        neptune.RegisterCallback<MouseLeaveEvent>(evt =>
        {
            resta.RemoveFromClassList("OBSCURO");
        });
        
        neptune.RegisterCallback<ClickEvent>(evt => {
            AbrirNiveles(evt);
            SessionData.SelectedWorldID = 2;
            print("Selected world: Subtraction");
        });

        uranus.RegisterCallback<MouseEnterEvent>(evt =>
        {
            multiplicacion.AddToClassList("OBSCURO");
        });

        uranus.RegisterCallback<MouseLeaveEvent>(evt =>
        {
            multiplicacion.RemoveFromClassList("OBSCURO");
        });
        
        uranus.RegisterCallback<ClickEvent>(evt => {
            AbrirNiveles(evt);
            SessionData.SelectedWorldID = 3;
            print("Selected world: Multiplication");
        });

        pluto.RegisterCallback<MouseEnterEvent>(evt =>
        {
            division.AddToClassList("OBSCURO");
        });

        pluto.RegisterCallback<MouseLeaveEvent>(evt =>
        {
            division.RemoveFromClassList("OBSCURO");
        });

        pluto.RegisterCallback<ClickEvent>(evt => {
            AbrirNiveles(evt);
            SessionData.SelectedWorldID = 4;
            print("Selected world: Division");
        });

        moon.RegisterCallback<MouseEnterEvent>(evt =>
        {
            union.AddToClassList("OBSCURO");
        });

        moon.RegisterCallback<MouseLeaveEvent>(evt =>
        {
            union.RemoveFromClassList("OBSCURO");
        });

        moon.RegisterCallback<ClickEvent>(evt => {
            AbrirNiveles(evt);
            SessionData.SelectedWorldID = 5;
            print("Selected world: Mixed");
        });

        void AbrirNiveles(ClickEvent evt)
        {
            SceneManager.LoadScene("Niveles");
        }

        info.RegisterCallback<ClickEvent>(AbrirInfo);

        void AbrirInfo(ClickEvent evt)
        {
            SceneManager.LoadScene("Informacion");
        }

        home.RegisterCallback<ClickEvent>(AbrirHome);

        void AbrirHome(ClickEvent evt)
        {
        SceneManager.LoadScene("MenuPrincipalScene");
        }

        regresar.RegisterCallback<ClickEvent>(AbrirRegresar);
        void AbrirRegresar(ClickEvent evt)
        {
            SceneManager.LoadScene("ModosJuegoScene");
        }

        confi.RegisterCallback<ClickEvent>(AbrirConfi);
        void AbrirConfi(ClickEvent evt)
        {
            SceneManager.LoadScene("Configuration");
        }
    }
    
        
}

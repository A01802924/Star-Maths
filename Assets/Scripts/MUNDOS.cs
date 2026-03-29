using UnityEngine;
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

        earth.RegisterCallback<MouseEnterEvent>(evt =>
        {
            suma.AddToClassList("OBSCURO");
        });

        earth.RegisterCallback<MouseLeaveEvent>(evt =>
        {
            suma.RemoveFromClassList("OBSCURO");
        });

        neptune.RegisterCallback<MouseEnterEvent>(evt =>
        {
            resta.AddToClassList("OBSCURO");
        });

        neptune.RegisterCallback<MouseLeaveEvent>(evt =>
        {
            resta.RemoveFromClassList("OBSCURO");
        });

        uranus.RegisterCallback<MouseEnterEvent>(evt =>
        {
            multiplicacion.AddToClassList("OBSCURO");
        });

        uranus.RegisterCallback<MouseLeaveEvent>(evt =>
        {
            multiplicacion.RemoveFromClassList("OBSCURO");
        });

        pluto.RegisterCallback<MouseEnterEvent>(evt =>
        {
            division.AddToClassList("OBSCURO");
        });

        pluto.RegisterCallback<MouseLeaveEvent>(evt =>
        {
            division.RemoveFromClassList("OBSCURO");
        });

        moon.RegisterCallback<MouseEnterEvent>(evt =>
        {
            union.AddToClassList("OBSCURO");
        });

        moon.RegisterCallback<MouseLeaveEvent>(evt =>
        {
            union.RemoveFromClassList("OBSCURO");
        });


    }
}

using Assets.Scripts.Core;
using UnityEngine;
using UnityEngine.UIElements;

public class DarkScreenBuilder : MonoBehaviour
{
    private VisualElement root;
    void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        root.Add(ConfigurationPreferences.DarkScreenLayer);
    }
}

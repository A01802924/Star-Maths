using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public struct ConfigOptions
{
    public string configName;
    public Sprite spriteSource;
}

public class Configurations : MonoBehaviour
{
    public List<ConfigOptions> configOptions;
    public VisualTreeAsset tabTemplate;
    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
    }
}

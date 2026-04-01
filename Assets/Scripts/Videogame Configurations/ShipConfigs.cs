using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public struct Ships
{
    public string name;
    public int price;
    public Sprite shipIcon;
    public bool isAlreadyOwned;
}

public class ShipConfigs : MonoBehaviour
{
    public List<Ships> shipsToSell;
    public VisualTreeAsset shipItemTemplate;
    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        var scrollView = root.Q<ScrollView>("ShipGrid");

        foreach (Ships ship in shipsToSell)
        {
            GenerateShipItem(ship, scrollView);
        }
    }

    private void GenerateShipItem(Ships ship, ScrollView container)
    {
        VisualElement newItem = shipItemTemplate.Instantiate();
        newItem.Q<Label>("ShipName").text = ship.name;
        newItem.Q<Label>("ShipPrice").text = ship.price.ToString();
        newItem.Q<VisualElement>("ShipImage").style.backgroundImage = new StyleBackground(ship.shipIcon);
        container.Add(newItem);
    }
}

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

[System.Serializable]
public struct Items
{
    public string name;
    public int price;
    public string type;
    public Sprite itemIcon;
    public bool isAlreadyOwned;
}

public class ItemConfig : MonoBehaviour
{
    public List<Items> itemsToSell;
    public VisualTreeAsset itemTemplate;
    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        var scrollView = root.Q<ScrollView>("ItemGrid");

        int itemCounter = 0;
        const int rowSize = 3;

        foreach (Items item in itemsToSell)
        {
            if (itemCounter % rowSize == 0)
                GenerateShipItemRow((itemCounter / rowSize) + 1, scrollView);
            GenerateShipItem(item, root.Q<VisualElement>("Row" + ((itemCounter / rowSize) + 1).ToString()));
            ++itemCounter;
        }
    }

    private void GenerateShipItemRow(int rowIndex, ScrollView container)
    {
        VisualElement newRow = new VisualElement
        {
            name = "Row" + rowIndex.ToString(),
            style =
            {
                flexDirection = FlexDirection.Row,
                flexWrap = Wrap.Wrap,
                justifyContent = Justify.Center,
                alignSelf = Align.Center,
                alignContent = Align.Center
            }
        };
        container.Add(newRow);
    }

    private void GenerateShipItem(Items item, VisualElement row)
    {
        VisualElement newItem = itemTemplate.Instantiate();
        newItem.Q<Label>("ItemName").text = item.name;
        newItem.Q<Label>("ItemType").text = item.type;
        newItem.Q<Label>("ItemPrice").text = item.price.ToString();
        newItem.Q<VisualElement>("ItemImage").style.backgroundImage = new StyleBackground(item.itemIcon);
        row.Add(newItem);
    }
}

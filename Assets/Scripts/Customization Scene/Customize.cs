using Assets.Scripts.Core;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Customize : MonoBehaviour
{
    private VisualElement shipHeaderWindowContainer;
    private VisualElement projectileHeaderWindowContainer;
    private VisualElement trailHeaderWindowContainer;
    private ScrollView scrollableShipContainer;
    private ScrollView scrollableProjectileContainer;
    private ScrollView scrollableTrailContainer;
    private VisualElement root;
    private VisualTreeAsset visualTree;
    private EventCallback<ClickEvent> _selectItem;
    private VisualElement selectedItemSource;
    private Button getBackButton;

    void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        selectedItemSource = root.Q<VisualElement>("ItemSource");
        selectedItemSource.style.backgroundImage = new StyleBackground(SessionData.CurrentShipItem.itemIcon);

        getBackButton = root.Q<Button>("GetBackButton");
        getBackButton.RegisterCallback<ClickEvent>(GetBack);

        shipHeaderWindowContainer = root.Q<VisualElement>("ShipHeaderWindowContainer");
        projectileHeaderWindowContainer = root.Q<VisualElement>("ShootHeaderWindowContainer");
        trailHeaderWindowContainer = root.Q<VisualElement>("TrailHeaderWindowContainer");

        scrollableShipContainer = root.Q<ScrollView>("ShipWindowScrollableContainer");
        scrollableProjectileContainer = root.Q<ScrollView>("ProjectileWindowScrollableContainer");
        scrollableTrailContainer = root.Q<ScrollView>("TrailWindowScrollableContainer");

        AddShipItemsToContainer();
        AddProjectileItemsToContainer();
        AddTrailItemsToContainer();

        DisplayShipScrollableContainer();

        shipHeaderWindowContainer.RegisterCallback<ClickEvent>(evt => { DisplayShipScrollableContainer(); });
        projectileHeaderWindowContainer.RegisterCallback<ClickEvent>(evt => { DisplayProjectileScrollableContainer(); });
        trailHeaderWindowContainer.RegisterCallback<ClickEvent>(evt => { DisplayTrailScrollableContainer(); });
    }

    private void GetBack(ClickEvent evt)
    {
        SceneManager.LoadScene("Store");
    }
    private void DisplayShipScrollableContainer()
    {
        if (ColorUtility.TryParseHtmlString("#382C5B", out Color currentWindowHeaderColor))
        {
            shipHeaderWindowContainer.style.backgroundColor = currentWindowHeaderColor;
        }
        if (ColorUtility.TryParseHtmlString("#42326F", out Color otherWindowHeadersColor))
        {
            trailHeaderWindowContainer.style.backgroundColor = otherWindowHeadersColor;
            projectileHeaderWindowContainer.style.backgroundColor = otherWindowHeadersColor;
        }
        scrollableShipContainer.style.display = DisplayStyle.Flex;
        scrollableProjectileContainer.style.display = DisplayStyle.None;
        scrollableTrailContainer.style.display = DisplayStyle.None;
    }
    private void DisplayProjectileScrollableContainer()
    {
        if (ColorUtility.TryParseHtmlString("#382C5B", out Color currentWindowHeaderColor))
        {
            projectileHeaderWindowContainer.style.backgroundColor = currentWindowHeaderColor;
        }
        if (ColorUtility.TryParseHtmlString("#42326F", out Color otherWindowHeadersColor))
        {
            shipHeaderWindowContainer.style.backgroundColor = otherWindowHeadersColor;
            trailHeaderWindowContainer.style.backgroundColor = otherWindowHeadersColor;
        }
        scrollableProjectileContainer.style.display = DisplayStyle.Flex;
        scrollableShipContainer.style.display = DisplayStyle.None;
        scrollableTrailContainer.style.display = DisplayStyle.None;
    }
    private void DisplayTrailScrollableContainer()
    {
        if (ColorUtility.TryParseHtmlString("#382C5B", out Color currentWindowHeaderColor))
        {
            trailHeaderWindowContainer.style.backgroundColor = currentWindowHeaderColor;
        }
        if (ColorUtility.TryParseHtmlString("#42326F", out Color otherWindowHeadersColor))
        {
            shipHeaderWindowContainer.style.backgroundColor = otherWindowHeadersColor;
            projectileHeaderWindowContainer.style.backgroundColor = otherWindowHeadersColor;
        }
        scrollableTrailContainer.style.display = DisplayStyle.Flex;
        scrollableShipContainer.style.display = DisplayStyle.None;
        scrollableProjectileContainer.style.display = DisplayStyle.None;
    }
    private void AddShipItemsToContainer()
    {
        foreach (Item item in ItemSet.ShipItems)
        {
            int index = SessionData.OwnedItems.IndexOf(item);
            if (index == -1)
            {
                AddItemToContainer(item, scrollableShipContainer, false, 'S');
            }
            else
            {
                AddItemToContainer(item, scrollableShipContainer, true, 'S');
            }
        }
    }
    private void AddProjectileItemsToContainer()
    {
        foreach (Item item in ItemSet.ProjectileItems)
        {
            int index = SessionData.OwnedItems.IndexOf(item);
            if (index == -1)
            {
                AddItemToContainer(item, scrollableProjectileContainer, false, 'P');
            }
            else
            {
                AddItemToContainer(item, scrollableProjectileContainer, true, 'P');
            }
        }
    }
    private void AddTrailItemsToContainer()
    {
        foreach (Item item in ItemSet.TrailItems)
        {
            int index = SessionData.OwnedItems.IndexOf(item);
            if (index == -1)
            {
                AddItemToContainer(item, scrollableTrailContainer, false, 'T');
            }
            else
            {
                AddItemToContainer(item, scrollableTrailContainer, true, 'T');
            }
        }
    }
    private void AddItemToContainer(Item item, ScrollView container, bool isOwned, char type)
    {
        visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI/Customization Scene/CustomizationItem.uxml");
        VisualElement newItem = visualTree.Instantiate();
        VisualElement itemSource = newItem.Q<VisualElement>("ItemSource");
        Label itemTitle = newItem.Q<Label>("ItemTitle");
        itemTitle.text = item.name;
        itemSource.style.backgroundImage = new StyleBackground(item.itemIcon);
        newItem.style.width = 200f;
        newItem.style.height = 200f;
        if (!isOwned)
        {
            newItem.Q<VisualElement>("BlockLayerContainer").style.display = DisplayStyle.Flex;
            if (ColorUtility.TryParseHtmlString("#525252", out Color disabledItemColor))
            {
                itemSource.style.unityBackgroundImageTintColor = new StyleColor(disabledItemColor);
                itemTitle.style.color = new StyleColor(disabledItemColor);
            }
        }
        else
        {
            if (_selectItem != null)
            {
                newItem.UnregisterCallback(_selectItem);
                _selectItem = null;
            }
            _selectItem = (evt) =>
            {
                DisplayItem(item, type);
            };
            newItem.RegisterCallback(_selectItem);
        }
        container.Add(newItem);
    }

    private void DisplayItem(Item item, char type)
    {
        selectedItemSource.style.backgroundImage = new StyleBackground(item.itemIcon);
        switch (type)
        {
            case 'S':
                SessionData.CurrentShipItem = item;
                print("New Ship Selection: " + item.name);
                break;
            case 'P':
                SessionData.CurrentProjectileItem = item;
                print("New Projectile Selection: " + item.name);
                break;
            case 'T':
                SessionData.CurrentTrailItem = item;
                print("New Trail Selection: " + item.name);
                break;
            default:
                break;
        }
    }
}

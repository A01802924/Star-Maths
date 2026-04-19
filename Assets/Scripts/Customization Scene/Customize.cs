using System.Collections.Generic;
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
    private VisualElement currentShipSelected;
    private VisualElement currentProjectileSelected;
    private VisualElement currentTrailSelected;
    private Button getBackButton;
    void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        root.Add(ConfigurationPreferences.DarkScreenLayer);
        AudioManager.Instance.Resume();

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
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickNewWindow);
        SceneManager.LoadScene("Store");
    }
    private void DisplayShipScrollableContainer()
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickNewTab);
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
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickNewTab);
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
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickNewTab);
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
                SelectNewItem(item, type, newItem);
            };
            newItem.RegisterCallback(_selectItem);
            if (item == SessionData.CurrentShipItem)
            {
                currentShipSelected = newItem;
                newItem.AddToClassList("item-container--active");
            }
            else if (item == SessionData.CurrentProjectileItem)
            {
                currentProjectileSelected = newItem;
                newItem.AddToClassList("item-container--active");
            }
            else if (item == SessionData.CurrentTrailItem)
            {
                currentTrailSelected = newItem;
                newItem.AddToClassList("item-container--active");
            }
            else
            {
                newItem.AddToClassList("item-container--enable-hover");
            }
        }
        container.Add(newItem);
    }
    private void ChangeItemSelectionStyle(VisualElement newUIElement, VisualElement formerUIElement)
    {
        formerUIElement.RemoveFromClassList("item-container--active");
        formerUIElement.AddToClassList("item-container--enable-hover");
        newUIElement.AddToClassList("item-container--active");
        newUIElement.RemoveFromClassList("item-container--enable-hover");
    }
    private void SelectNewItem(Item item, char type, VisualElement uiElement)
    {
        /*
        Recomiendo encarecidamente llamar desde aquí la función de gestión de la base de datos:
        TODO: Cada vez que el usuario llame a la función SelectNewItem(), el sistema
        debería enviar estos cambios a las bases de datos:
        - Qué nuevo elemento acaba de seleccionar el usuario como su preferido
          (teniendo en cuenta que todos los usuarios deben tener SIEMPRE SOLO UNA nave, UN proyectil
          y UNA estela como sus selecciones de elementos actuales, de modo que sean estos los que
          el sistema utilice cuando el usuario inicie una partida)
        Tengan en cuenta que dichos cambios de datos se pueden recuperar con bastante facilidad de la
        clase estática SessionData mediante sus atributos SessionData.CurrentShipItem,
        SessionData.CurrentProjectileItem y SessionData.CurrentTrailItem
        */
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickSelectItem);
        selectedItemSource.style.backgroundImage = new StyleBackground(item.itemIcon);
        switch (type)
        {
            case 'S':
                SessionData.CurrentShipItem = item;
                ChangeItemSelectionStyle(uiElement, currentShipSelected);
                currentShipSelected = uiElement;
                break;
            case 'P':
                SessionData.CurrentProjectileItem = item;
                ChangeItemSelectionStyle(uiElement, currentProjectileSelected);
                currentProjectileSelected = uiElement;
                break;
            case 'T':
                SessionData.CurrentTrailItem = item;
                ChangeItemSelectionStyle(uiElement, currentTrailSelected);
                currentTrailSelected = uiElement;
                break;
            default:
                break;
        }
        /*
        Y llamar al final la función con sus respectivos parámetros:
        SendItemSelectionToDB(item, type);
        Podrían manejar el tipo de Item por la variable char type, casi con la misma
        lógica como se implementó en esta función (a través de un switch).
        */
    }
    /*
    Quizás crear una función como:
    private void SendItemSelectionToDB(Item item, char type) {
        Líneas de código
    }
    O, mejor aún, crear una clase DataBase para agrupar
    todas las funciones relacionadas con la base de datos
    */
}
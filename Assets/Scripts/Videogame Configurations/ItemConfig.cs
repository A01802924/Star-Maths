using UnityEngine;
using UnityEngine.UIElements;
using Assets.Scripts.Core;
using System.Collections.Generic;
public class ItemConfig : MonoBehaviour
{
    public VisualTreeAsset itemTemplate;
    private VisualElement root;
    private ScrollView scrollableShipContainer;
    private ScrollView scrollableProjectileContainer;
    private ScrollView scrollableTrailContainer;
    private VisualElement confirmPurchaseDialog;
    private VisualElement unaffordablePurchaseDialog;
    private Label numStarsLabel;
    private Button confirmPurchaseButton;
    private Button cancelPurchaseButton;
    private VisualElement buyCrossButton;
    private VisualElement unaffordableCrossButton;
    private VisualElement shipWindowHeader;
    private VisualElement projectileWindowHeader;
    private VisualElement trailWindowHeader;
    private Button closeUnaffordableButton;
    private EventCallback<ClickEvent> _confirmCallback;
    private EventCallback<ClickEvent> _cancelCallback;
    private EventCallback<ClickEvent> _crossCallback;
    private readonly Dictionary<Item, VisualElement> itemUIMap = new();
    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        root.Add(ConfigurationPreferences.DarkScreenLayer);
        AudioManager.Instance.Resume();

        scrollableShipContainer = root.Q<ScrollView>("ShipItemGrid");
        scrollableProjectileContainer = root.Q<ScrollView>("ProjectileItemGrid");
        scrollableTrailContainer = root.Q<ScrollView>("TrailItemGrid");

        confirmPurchaseDialog = root.Q<VisualElement>("PopUpBuyDialogContainer");
        unaffordablePurchaseDialog = root.Q<VisualElement>("PopUpUnaffordableDialogContainer");
        numStarsLabel = root.Q<Label>("NumStars");
        numStarsLabel.text = SessionData.coins.ToString();

        shipWindowHeader = root.Q<VisualElement>("ShipHeaderContainer");
        projectileWindowHeader = root.Q<VisualElement>("ProjectileHeaderContainer");
        trailWindowHeader = root.Q<VisualElement>("TrailHeaderContainer");
        shipWindowHeader.RegisterCallback<ClickEvent>((evt) => { AudioManager.Instance.PlayUISFX(AudioClipSet.ClickNewTab); SelectShipWindow(); });
        projectileWindowHeader.RegisterCallback<ClickEvent>((evt) => { AudioManager.Instance.PlayUISFX(AudioClipSet.ClickNewTab); SelectProjectileWindow(); });
        trailWindowHeader.RegisterCallback<ClickEvent>((evt) => { AudioManager.Instance.PlayUISFX(AudioClipSet.ClickNewTab); SelectTrailWindow(); });

        confirmPurchaseButton = root.Q<Button>("ConfirmBuyButton");
        cancelPurchaseButton = root.Q<Button>("CancelBuyButton");
        buyCrossButton = root.Q<VisualElement>("BuyCrossButtonContainer");
        unaffordableCrossButton = root.Q<VisualElement>("UnaffordableCrossButtonContainer");
        closeUnaffordableButton = root.Q<Button>("CloseUnaffordableButton");

        unaffordableCrossButton.RegisterCallback<ClickEvent>(CloseUnaffordableDialog);
        closeUnaffordableButton.RegisterCallback<ClickEvent>(CloseUnaffordableDialog);

        StartCoroutine(GetComponent<TiendaBD>().ObtenerTienda(() =>
        {
            scrollableProjectileContainer.Clear();
            scrollableShipContainer.Clear();
            scrollableTrailContainer.Clear();

            BuildStore();
            SelectShipWindow();

            numStarsLabel.text = SessionData.coins.ToString();
        }));
        SelectShipWindow();
    }
    private void BuildStore()
    {
        foreach (Item item in ItemSet.ShipItems)
        {
            AddItemToGrid(item, "Nave", scrollableShipContainer);
        }
        foreach (Item item in ItemSet.ProjectileItems)
        {
            AddItemToGrid(item, "Disparo", scrollableProjectileContainer);
        }
        foreach (Item item in ItemSet.TrailItems)
        {
            AddItemToGrid(item, "Estela", scrollableTrailContainer);
        }
    }
    private void SelectShipWindow()
    {
        if (ColorUtility.TryParseHtmlString("#261C47", out Color currentWindowHeaderColor))
        {
            shipWindowHeader.style.backgroundColor = currentWindowHeaderColor;
        }
        if (ColorUtility.TryParseHtmlString("#382C5B", out Color otherWindowHeadersColor))
        {
            projectileWindowHeader.style.backgroundColor = otherWindowHeadersColor;
            trailWindowHeader.style.backgroundColor = otherWindowHeadersColor;
        }
        scrollableShipContainer.style.display = DisplayStyle.Flex;
        scrollableProjectileContainer.style.display = DisplayStyle.None;
        scrollableTrailContainer.style.display = DisplayStyle.None;
    }
    private void SelectProjectileWindow()
    {
        if (ColorUtility.TryParseHtmlString("#261C47", out Color currentWindowHeaderColor))
        {
            projectileWindowHeader.style.backgroundColor = currentWindowHeaderColor;
        }
        if (ColorUtility.TryParseHtmlString("#382C5B", out Color otherWindowHeadersColor))
        {
            shipWindowHeader.style.backgroundColor = otherWindowHeadersColor;
            trailWindowHeader.style.backgroundColor = otherWindowHeadersColor;
        }
        scrollableProjectileContainer.style.display = DisplayStyle.Flex;
        scrollableShipContainer.style.display = DisplayStyle.None;
        scrollableTrailContainer.style.display = DisplayStyle.None;
    }
    private void SelectTrailWindow()
    {
        if (ColorUtility.TryParseHtmlString("#261C47", out Color currentWindowHeaderColor))
        {
            trailWindowHeader.style.backgroundColor = currentWindowHeaderColor;
        }
        if (ColorUtility.TryParseHtmlString("#382C5B", out Color otherWindowHeadersColor))
        {
            shipWindowHeader.style.backgroundColor = otherWindowHeadersColor;
            projectileWindowHeader.style.backgroundColor = otherWindowHeadersColor;
        }
        scrollableTrailContainer.style.display = DisplayStyle.Flex;
        scrollableShipContainer.style.display = DisplayStyle.None;
        scrollableProjectileContainer.style.display = DisplayStyle.None;
    }
    private void OnDisable()
    {
        unaffordableCrossButton?.UnregisterCallback<ClickEvent>(CloseUnaffordableDialog);
        closeUnaffordableButton?.UnregisterCallback<ClickEvent>(CloseUnaffordableDialog);
        CleanUpDialogCallbacks();
    }
    private void AddItemToGrid(Item item, string type, ScrollView scrollView)
    {
        VisualElement newItem = itemTemplate.Instantiate();
        newItem.Q<Label>("ItemName").text = item.name;
        newItem.Q<Label>("ItemType").text = type;
        newItem.Q<Label>("ItemPrice").text = item.price.ToString();
        newItem.Q<VisualElement>("ItemImage").style.backgroundImage = new StyleBackground(item.itemIcon);
        int index = SessionData.OwnedItems.IndexOf(item);
        if (index != -1)
        {
            MarkItemAsOwned(newItem);
        }
        newItem.RegisterCallback<ClickEvent>(evt => OpenConfirmDialog(item, newItem));
        itemUIMap[item] = newItem;
        scrollView.Add(newItem);
    }
    private void MarkItemAsOwned(VisualElement item)
    {
        item.Q<VisualElement>("OwnedIconSource").style.display = DisplayStyle.Flex;
        if (ColorUtility.TryParseHtmlString("#76D7AA", out Color ownedColor))
        {
            item.Q<Label>("ItemName").style.color = ownedColor;
            item.Q<Label>("ItemPrice").style.color = ownedColor;
            item.Q<Image>("StarImage").tintColor = ownedColor;
            item.Q<VisualElement>("ItemImage").style.unityBackgroundImageTintColor = ownedColor;
        }
        if (ColorUtility.TryParseHtmlString("#358A63", out Color darkOwnedColor))
        {
            item.Q<Label>("ItemType").style.color = darkOwnedColor;
        }
    }
    private void OpenConfirmDialog(Item item, VisualElement uiElement)
    {
        if (SessionData.OwnedItems.IndexOf(item) == -1)
        {
            AudioManager.Instance.PlayUISFX(AudioClipSet.PopUpDialog);
            if (item.price <= SessionData.coins)
            {
                CleanUpDialogCallbacks();

                confirmPurchaseDialog.style.display = DisplayStyle.Flex;
                root.Q<Label>("BuyDescription").text = $"¿Estás seguro de comprar {item.name} por {item.price}?";
                root.Q<VisualElement>("ItemBuySource").style.backgroundImage = new StyleBackground(item.itemIcon);

                _confirmCallback = (evt) => PurchaseItem(item, uiElement);
                _cancelCallback = (evt) => CloseConfirmPurchaseDialog();
                _crossCallback = (evt) => CloseConfirmPurchaseDialog();

                confirmPurchaseButton.RegisterCallback(_confirmCallback);
                cancelPurchaseButton.RegisterCallback(_cancelCallback);
                buyCrossButton.RegisterCallback(_crossCallback);
            }
            else
            {
                unaffordablePurchaseDialog.style.display = DisplayStyle.Flex;
            }
        }
    }
    private void CleanUpDialogCallbacks()
    {
        if (_confirmCallback != null)
        {
            confirmPurchaseButton.UnregisterCallback(_confirmCallback);
            _confirmCallback = null;
        }
        if (_cancelCallback != null)
        {
            cancelPurchaseButton.UnregisterCallback(_cancelCallback);
            _cancelCallback = null;
        }
        if (_crossCallback != null)
        {
            buyCrossButton.UnregisterCallback(_crossCallback);
            _crossCallback = null;
        }
    }
    private void PurchaseItem(Item item, VisualElement uiElement)
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickAccept);
        print("Initial coin status: " + SessionData.coins);
        print("Item price: " + item.price);
        SessionData.coins -= item.price;
        numStarsLabel.text = SessionData.coins.ToString();
        SessionData.OwnedItems.Add(item);
        MarkItemAsOwned(uiElement);
        GetComponent<TiendaBD>().ComprarItem(id_juador_instance.instance.id_jugador, item.index);
        print("Coins status after purchase: " + SessionData.coins);

        CleanUpDialogCallbacks();
        confirmPurchaseDialog.style.display = DisplayStyle.None;
    }
    private void CloseConfirmPurchaseDialog()
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickDiscard);
        CleanUpDialogCallbacks();
        confirmPurchaseDialog.style.display = DisplayStyle.None;

    }
    private void CloseUnaffordableDialog(ClickEvent evt)
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickDiscard);
        unaffordablePurchaseDialog.style.display = DisplayStyle.None;
    }
}
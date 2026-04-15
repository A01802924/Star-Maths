using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;
using Assets.Scripts.Core;
using System;

[Serializable]
public struct Items
{
    public int index;
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
    private List<VisualElement> displayedItems = new();
    private VisualElement root;
    private ScrollView scrollableContainer;
    private VisualElement confirmPurchaseDialog;
    private VisualElement unaffordablePurchaseDialog;
    private Label numStarsLabel;
    private Button confirmPurchaseButton;
    private Button cancelPurchaseButton;
    private VisualElement buyCrossButton;
    private VisualElement unaffordableCrossButton;
    private Button closeUnaffordableButton;
    private EventCallback<ClickEvent> _confirmCallback;
    private EventCallback<ClickEvent> _cancelCallback;
    private EventCallback<ClickEvent> _crossCallback;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        scrollableContainer = root.Q<ScrollView>("ItemGrid");
        confirmPurchaseDialog = root.Q<VisualElement>("PopUpBuyDialogContainer");
        unaffordablePurchaseDialog = root.Q<VisualElement>("PopUpUnaffordableDialogContainer");
        numStarsLabel = root.Q<Label>("NumStars");
        numStarsLabel.text = SessionData.coins.ToString();

        confirmPurchaseButton = root.Q<Button>("ConfirmBuyButton");
        cancelPurchaseButton = root.Q<Button>("CancelBuyButton");
        buyCrossButton = root.Q<VisualElement>("BuyCrossButtonContainer");
        unaffordableCrossButton = root.Q<VisualElement>("UnaffordableCrossButtonContainer");
        closeUnaffordableButton = root.Q<Button>("CloseUnaffordableButton");

        unaffordableCrossButton.RegisterCallback<ClickEvent>(CloseUnaffordableDialog);
        closeUnaffordableButton.RegisterCallback<ClickEvent>(CloseUnaffordableDialog);

        foreach (Items item in itemsToSell) GenerateShipItem(item);
    }

    private void OnDisable()
    {
        unaffordableCrossButton?.UnregisterCallback<ClickEvent>(CloseUnaffordableDialog);
        closeUnaffordableButton?.UnregisterCallback<ClickEvent>(CloseUnaffordableDialog);
        CleanUpDialogCallbacks();
    }

    private void GenerateShipItem(Items item)
    {
        VisualElement newItem = itemTemplate.Instantiate();
        newItem.Q<Label>("ItemName").text = item.name;
        newItem.Q<Label>("ItemType").text = item.type;
        newItem.Q<Label>("ItemPrice").text = item.price.ToString();
        newItem.Q<VisualElement>("ItemImage").style.backgroundImage = new StyleBackground(item.itemIcon);

        newItem.RegisterCallback<ClickEvent>(evt => OpenConfirmDialog(item));

        displayedItems.Add(newItem);
        scrollableContainer.Add(newItem);
    }

    private void OpenConfirmDialog(Items item)
    {
        if (item.price <= SessionData.coins)
        {
            CleanUpDialogCallbacks();

            confirmPurchaseDialog.style.display = DisplayStyle.Flex;
            root.Q<Label>("BuyDescription").text = $"¿Estás seguro de comprar {item.name} por {item.price}?";
            root.Q<VisualElement>("ItemBuySource").style.backgroundImage = new StyleBackground(item.itemIcon);

            _confirmCallback = (evt) => PurchaseItem(item);
            _cancelCallback = (evt) => CloseConfirmPurchaseDialog(evt);
            _crossCallback  = (evt) => CloseConfirmPurchaseDialog(evt);

            confirmPurchaseButton.RegisterCallback(_confirmCallback);
            cancelPurchaseButton.RegisterCallback(_cancelCallback);
            buyCrossButton.RegisterCallback(_crossCallback);
        }
        else
        {
            unaffordablePurchaseDialog.style.display = DisplayStyle.Flex;
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

    private void PurchaseItem(Items item)
    {
        print("Initial coin status: " + SessionData.coins);
        print("Item price: " + item.price);
        SessionData.coins -= item.price;
        numStarsLabel.text = SessionData.coins.ToString();
        print("Coins status after purchase: " + SessionData.coins);
        // TODO: update new coins status to DB
        print("Handle here DB coins status update...");

        CleanUpDialogCallbacks();
        confirmPurchaseDialog.style.display = DisplayStyle.None;
    }

    private void CloseConfirmPurchaseDialog(ClickEvent evt)
    {
        CleanUpDialogCallbacks();
        confirmPurchaseDialog.style.display = DisplayStyle.None;
    }

    private void CloseUnaffordableDialog(ClickEvent evt)
    {
        unaffordablePurchaseDialog.style.display = DisplayStyle.None;
    }
}
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
    private ScrollView scrollableBundleContainer;
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
    private VisualElement bundleWindowHeader;
    private Button closeUnaffordableButton;
    private EventCallback<ClickEvent> _confirmCallback;
    private EventCallback<ClickEvent> _cancelCallback;
    private EventCallback<ClickEvent> _crossCallback;
    private readonly Dictionary<Item, VisualElement> itemUIMap = new();
    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        root.Add(ConfigurationPreferences.DarkScreenLayer);

        scrollableShipContainer = root.Q<ScrollView>("ShipItemGrid");
        scrollableProjectileContainer = root.Q<ScrollView>("ProjectileItemGrid");
        scrollableTrailContainer = root.Q<ScrollView>("TrailItemGrid");
        scrollableBundleContainer = root.Q<ScrollView>("BundleItemGrid");

        confirmPurchaseDialog = root.Q<VisualElement>("PopUpBuyDialogContainer");
        unaffordablePurchaseDialog = root.Q<VisualElement>("PopUpUnaffordableDialogContainer");
        numStarsLabel = root.Q<Label>("NumStars");
        numStarsLabel.text = SessionData.coins.ToString();

        shipWindowHeader = root.Q<VisualElement>("ShipHeaderContainer");
        projectileWindowHeader = root.Q<VisualElement>("ProjectileHeaderContainer");
        trailWindowHeader = root.Q<VisualElement>("TrailHeaderContainer");
        bundleWindowHeader = root.Q<VisualElement>("BundleHeaderContainer");
        shipWindowHeader.RegisterCallback<ClickEvent>((evt) => SelectShipWindow());
        projectileWindowHeader.RegisterCallback<ClickEvent>((evt) => SelectProjectileWindow());
        trailWindowHeader.RegisterCallback<ClickEvent>((evt) => SelectTrailWindow());
        bundleWindowHeader.RegisterCallback<ClickEvent>((evt) => SelectBundleWindow());

        confirmPurchaseButton = root.Q<Button>("ConfirmBuyButton");
        cancelPurchaseButton = root.Q<Button>("CancelBuyButton");
        buyCrossButton = root.Q<VisualElement>("BuyCrossButtonContainer");
        unaffordableCrossButton = root.Q<VisualElement>("UnaffordableCrossButtonContainer");
        closeUnaffordableButton = root.Q<Button>("CloseUnaffordableButton");

        unaffordableCrossButton.RegisterCallback<ClickEvent>(CloseUnaffordableDialog);
        closeUnaffordableButton.RegisterCallback<ClickEvent>(CloseUnaffordableDialog);

        BuildStore();
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
        foreach (Item item in ItemSet.BundleItems)
        {
            AddItemToGrid(item, "Bundle Set", scrollableBundleContainer);
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
            bundleWindowHeader.style.backgroundColor = otherWindowHeadersColor;
            projectileWindowHeader.style.backgroundColor = otherWindowHeadersColor;
            trailWindowHeader.style.backgroundColor = otherWindowHeadersColor;
        }
        scrollableShipContainer.style.display = DisplayStyle.Flex;
        scrollableProjectileContainer.style.display = DisplayStyle.None;
        scrollableTrailContainer.style.display = DisplayStyle.None;
        scrollableBundleContainer.style.display = DisplayStyle.None;
    }
    private void SelectProjectileWindow()
    {
        if (ColorUtility.TryParseHtmlString("#261C47", out Color currentWindowHeaderColor))
        {
            projectileWindowHeader.style.backgroundColor = currentWindowHeaderColor;
        }
        if (ColorUtility.TryParseHtmlString("#382C5B", out Color otherWindowHeadersColor))
        {
            bundleWindowHeader.style.backgroundColor = otherWindowHeadersColor;
            shipWindowHeader.style.backgroundColor = otherWindowHeadersColor;
            trailWindowHeader.style.backgroundColor = otherWindowHeadersColor;
        }
        scrollableProjectileContainer.style.display = DisplayStyle.Flex;
        scrollableShipContainer.style.display = DisplayStyle.None;
        scrollableTrailContainer.style.display = DisplayStyle.None;
        scrollableBundleContainer.style.display = DisplayStyle.None;
    }
    private void SelectTrailWindow()
    {
        if (ColorUtility.TryParseHtmlString("#261C47", out Color currentWindowHeaderColor))
        {
            trailWindowHeader.style.backgroundColor = currentWindowHeaderColor;
        }
        if (ColorUtility.TryParseHtmlString("#382C5B", out Color otherWindowHeadersColor))
        {
            bundleWindowHeader.style.backgroundColor = otherWindowHeadersColor;
            shipWindowHeader.style.backgroundColor = otherWindowHeadersColor;
            projectileWindowHeader.style.backgroundColor = otherWindowHeadersColor;
        }
        scrollableTrailContainer.style.display = DisplayStyle.Flex;
        scrollableShipContainer.style.display = DisplayStyle.None;
        scrollableProjectileContainer.style.display = DisplayStyle.None;
        scrollableBundleContainer.style.display = DisplayStyle.None;
    }
    private void SelectBundleWindow()
    {
        if (ColorUtility.TryParseHtmlString("#261C47", out Color currentWindowHeaderColor))
        {
            bundleWindowHeader.style.backgroundColor = currentWindowHeaderColor;
        }
        if (ColorUtility.TryParseHtmlString("#382C5B", out Color otherWindowHeadersColor))
        {
            trailWindowHeader.style.backgroundColor = otherWindowHeadersColor;
            shipWindowHeader.style.backgroundColor = otherWindowHeadersColor;
            projectileWindowHeader.style.backgroundColor = otherWindowHeadersColor;
        }
        scrollableBundleContainer.style.display = DisplayStyle.Flex;
        scrollableShipContainer.style.display = DisplayStyle.None;
        scrollableProjectileContainer.style.display = DisplayStyle.None;
        scrollableTrailContainer.style.display = DisplayStyle.None;
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
        newItem.RegisterCallback<ClickEvent>(evt => OpenConfirmDialog(item, newItem, type));
        itemUIMap[item] = newItem;
        scrollView.Add(newItem);
    }
    private VisualElement GetVisualElementItem(Item item)
    {
        return itemUIMap.TryGetValue(item, out VisualElement uiElement) ? uiElement : null;
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
    private void OpenConfirmDialog(Item item, VisualElement uiElement, string type)
    {
        if (SessionData.OwnedItems.IndexOf(item) == -1)
        {
            if (item.price <= SessionData.coins)
            {
                CleanUpDialogCallbacks();

                confirmPurchaseDialog.style.display = DisplayStyle.Flex;
                root.Q<Label>("BuyDescription").text = $"¿Estás seguro de comprar {item.name} por {item.price}?";
                root.Q<VisualElement>("ItemBuySource").style.backgroundImage = new StyleBackground(item.itemIcon);

                _confirmCallback = (evt) => PurchaseItem(item, uiElement, type);
                _cancelCallback = (evt) => CloseConfirmPurchaseDialog(evt);
                _crossCallback = (evt) => CloseConfirmPurchaseDialog(evt);

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
    private void PurchaseItem(Item item, VisualElement uiElement, string type)
    {
        /*
        Recomiendo encarecidamente llamar desde aquí a la función de gestión de la base de datos:
        TODO: Cada vez que el usuario llame a la función PurchaseItem(), el sistema
        debería enviar estos cambios a la base de datos:
        - Qué nuevo objeto acaba de comprar el usuario
          (ya sea una nave, un proyectil o una estela,
          el sistema solo envía a la base de datos el atributo Item.name
          de la clase estática Item)
        - Actualizar el total de monedas/estrellas que le quedan al usuario tras la compra
          Tengan en cuenta que estos cambios en los datos se pueden recuperar fácilmente de la
          clase estática SessionData mediante sus atributos SessionData.coins y
          SessionData.OwnedItems
        */
        print("Initial coin status: " + SessionData.coins);
        print("Item price: " + item.price);
        SessionData.coins -= item.price;
        numStarsLabel.text = SessionData.coins.ToString();
        SessionData.OwnedItems.Add(item);
        MarkItemAsOwned(uiElement);
        if (type == "Bundle Set")
        {
            /*
            Para el caso en que el usuario compre un Bundle (un bundle en
            este sentido sería un comodín que, con solo comprarlo, ya habilite el uso
            de todos los sprites del color del bundle -naves, proyectiles y estelas-
            en una sola compra) se debería iterar la función de la Base de Datos para
            actualizar todos los items que se involucren en cada bundle, algo parecido
            como describo a continuación:
            */
            switch (item.index)
            {
                case 0:
                    for (int i = 2; i <= 47; i += 5)
                    {
                        SessionData.OwnedItems.Add(ItemSet.ShipItems[i]);
                        MarkItemAsOwned(GetVisualElementItem(ItemSet.ShipItems[i]));
                        // SendPurhcaseToDB(ItemSet.ShipItems[i]);
                    }
                    for (int i = 2; i <= 32; i += 5)
                    {
                        SessionData.OwnedItems.Add(ItemSet.ProjectileItems[i]);
                        SessionData.OwnedItems.Add(ItemSet.TrailItems[i]);
                        MarkItemAsOwned(GetVisualElementItem(ItemSet.ProjectileItems[i]));
                        MarkItemAsOwned(GetVisualElementItem(ItemSet.TrailItems[i]));
                        // SendPurhcaseToDB(ItemSet.ProjectileItems[i]);
                        // SendPurhcaseToDB(ItemSet.TrailItems[i]);
                    }
                    break;
                case 1:
                    for (int i = 3; i <= 48; i += 5)
                    {
                        SessionData.OwnedItems.Add(ItemSet.ShipItems[i]);
                        MarkItemAsOwned(GetVisualElementItem(ItemSet.ShipItems[i]));
                        // SendPurhcaseToDB(ItemSet.ShipItems[i]);
                    }
                    for (int i = 3; i <= 33; i += 5)
                    {
                        SessionData.OwnedItems.Add(ItemSet.ProjectileItems[i]);
                        SessionData.OwnedItems.Add(ItemSet.TrailItems[i]);
                        MarkItemAsOwned(GetVisualElementItem(ItemSet.ProjectileItems[i]));
                        MarkItemAsOwned(GetVisualElementItem(ItemSet.TrailItems[i]));
                        // SendPurhcaseToDB(ItemSet.ProjectileItems[i]);
                        // SendPurhcaseToDB(ItemSet.TrailItems[i]);
                    }
                    break;
                case 2:
                    for (int i = 0; i <= 45; i += 5)
                    {
                        SessionData.OwnedItems.Add(ItemSet.ShipItems[i]);
                        MarkItemAsOwned(GetVisualElementItem(ItemSet.ShipItems[i]));
                        // SendPurhcaseToDB(ItemSet.ShipItems[i]);
                    }
                    for (int i = 0; i <= 30; i += 5)
                    {
                        SessionData.OwnedItems.Add(ItemSet.ProjectileItems[i]);
                        SessionData.OwnedItems.Add(ItemSet.TrailItems[i]);
                        MarkItemAsOwned(GetVisualElementItem(ItemSet.ProjectileItems[i]));
                        MarkItemAsOwned(GetVisualElementItem(ItemSet.TrailItems[i]));
                        // SendPurhcaseToDB(ItemSet.ProjectileItems[i]);
                        // SendPurhcaseToDB(ItemSet.TrailItems[i]);
                    }
                    break;
                case 3:
                    for (int i = 4; i <= 49; i += 5)
                    {
                        SessionData.OwnedItems.Add(ItemSet.ShipItems[i]);
                        MarkItemAsOwned(GetVisualElementItem(ItemSet.ShipItems[i]));
                        // SendPurhcaseToDB(ItemSet.ShipItems[i]);
                    }
                    for (int i = 4; i <= 34; i += 5)
                    {
                        SessionData.OwnedItems.Add(ItemSet.ProjectileItems[i]);
                        SessionData.OwnedItems.Add(ItemSet.TrailItems[i]);
                        MarkItemAsOwned(GetVisualElementItem(ItemSet.ProjectileItems[i]));
                        MarkItemAsOwned(GetVisualElementItem(ItemSet.TrailItems[i]));
                        // SendPurhcaseToDB(ItemSet.ProjectileItems[i]);
                        // SendPurhcaseToDB(ItemSet.TrailItems[i]);
                    }
                    break;
                default:
                    break;
            }
            /*
            IMPORTANTE: Es posible que la implementación de estos 'Bundles' no se lleve a
            cabo para el final del videojuego, así que prioricen llamar a su función de
            base de datos para el caso general (es decir, cuando tipo de item no sea de Bundle)
            */
        }
        else
        {
            /*
            Que sería en este bloque else (Todos los items que no son de tipo Bundle deberán
            llegarán a esta parte del código, por lo que aquí se llamaría a la función de la 
            base de datos):
            SendPurhcaseToDB(item);
            */
        }
        print("Coins status after purchase: " + SessionData.coins);

        CleanUpDialogCallbacks();
        confirmPurchaseDialog.style.display = DisplayStyle.None;
    }
    /*
    Quizás crear una función como:
    private void SendPurhcaseToDB(Item item) {
        Líneas de código
    }
    O, mejor aún, crear una clase DataBase para agrupar
    todas las funciones relacionadas con la base de datos
    */
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
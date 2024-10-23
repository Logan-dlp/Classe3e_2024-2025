using AmazingShop.Display;
using AmazingShop.Inventory;
using AmazingShop.Item;
using AmazingShop.Trading;
using UnityEngine;
using UnityEngine.EventSystems;

public class SellItemController : MonoBehaviour, IPointerClickHandler
{
    private ItemToDisplay _itemToDisplay;
    private MoneyManagement _moneyManagement;
    private DisplayInventoryItem _displayInventory;

    private void Start()
    {
        _itemToDisplay = GetComponentInChildren<ItemToDisplay>();
        _moneyManagement = FindObjectOfType<MoneyManagement>();
        _displayInventory = FindObjectOfType<DisplayInventoryItem>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_itemToDisplay != null && _moneyManagement != null)
        {
            ItemData clickedItemData = _itemToDisplay.ItemData;

            if (clickedItemData.CurrentQuantity > 0)
            {
                clickedItemData.CurrentQuantity--;
                _moneyManagement.AddMoney(clickedItemData.SellingPrice);

                Debug.Log($"Article cliqué : {clickedItemData.Name}, Prix : {clickedItemData.SellingPrice}, Nombre : {clickedItemData.CurrentQuantity}");

                ItemPanelController itemPanelController = GetComponentInChildren<ItemPanelController>();
                if (itemPanelController != null)
                {
                    itemPanelController.SetNumberOnPanel(clickedItemData.CurrentQuantity);
                }

                if (clickedItemData.CurrentQuantity == 0)
                {
                    _displayInventory.RemoveItem(clickedItemData);
                    Destroy(_itemToDisplay.gameObject);
                }
            }
            else
            {
                Debug.LogWarning("Quantité d'article insuffisante pour la vente.");
            }
        }
    }
}
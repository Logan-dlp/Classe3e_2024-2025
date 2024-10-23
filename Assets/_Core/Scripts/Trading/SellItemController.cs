using AmazingShop.Display;
using AmazingShop.Item;
using AmazingShop.Trading;
using UnityEngine;
using UnityEngine.EventSystems;

public class SellItemController : MonoBehaviour, IPointerClickHandler
{
    private ItemToDisplay _itemToDisplay;
    private MoneyManagement _moneyManagement;

    private void Start()
    {
        _itemToDisplay = GetComponentInChildren<ItemToDisplay>();
        _moneyManagement = FindObjectOfType<MoneyManagement>();
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

                Debug.Log($"Article cliqu� : {clickedItemData.Name}, Prix : {clickedItemData.SellingPrice}, Nombre : {clickedItemData.CurrentQuantity}");

                ItemPanelController itemPanelController = GetComponentInChildren<ItemPanelController>();
                if (itemPanelController != null)
                {
                    itemPanelController.SetNumberOnPanel(clickedItemData.CurrentQuantity);
                }
            }
            else
            {
                Debug.LogWarning("Quantit� d'article insuffisante pour la vente.");
            }
        }
    }
}
using AmazingShop.Display;
using AmazingShop.Item;
using AmazingShop.Trading;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AmazingShop.Buy
{
    public class BuyItemController : MonoBehaviour, IPointerClickHandler
    {
        private DisplayItemFrame _displayItemFrame;
        private ItemToDisplay _itemToDisplay;
        private MoneyManagement _moneyManagement;
        private void Start()
        {
            _displayItemFrame = GetComponentInParent<DisplayItemFrame>();
            _itemToDisplay = GetComponentInChildren<ItemToDisplay>();
            _moneyManagement = FindObjectOfType<MoneyManagement>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_displayItemFrame != null && _itemToDisplay != null && _moneyManagement != null)
            {
                ItemData clickedItemData = _itemToDisplay.ItemData;

                if (_moneyManagement.MoneyCount >= clickedItemData.PurchasePrice)
                {
                    clickedItemData.CurrentQuantity++;
                    _moneyManagement.WithdrawMoney(clickedItemData.PurchasePrice);

                    Debug.Log($"Article cliqu� : {clickedItemData.Name}, Prix : {clickedItemData.PurchasePrice}, Nombre : {clickedItemData.CurrentQuantity}");

                    ItemPanelController itemPanelController = GetComponentInChildren<ItemPanelController>();
                    if (itemPanelController != null)
                    {
                        itemPanelController.SetNumberOnPanel(clickedItemData.CurrentQuantity);
                    }

                    _displayItemFrame.DestroyItem(gameObject);
                }
                else
                {
                    Debug.LogWarning("Fonds insuffisants pour acheter cet article.");
                }
            }
        }
    }
}
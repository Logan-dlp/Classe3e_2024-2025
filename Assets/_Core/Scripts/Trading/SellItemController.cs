using AmazingShop.Display;
using AmazingShop.Inventory;
using AmazingShop.Item;
using AmazingShop.Trading;
using UnityEngine;
using UnityEngine.EventSystems;


namespace AmazingShop.Buy
{
    public class SellItemController : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Events.ItemEvent _itemEvent;

        private ItemToDisplay _itemToDisplay;
        private MoneyManagement _moneyManagement;
        private DisplayInventoryItem _displayInventory;

        private void Start()
        {
            _itemToDisplay = GetComponentInChildren<ItemToDisplay>();
            _moneyManagement = FindObjectOfType<MoneyManagement>();
            _displayInventory = FindObjectOfType<DisplayInventoryItem>();

            _itemEvent = _itemToDisplay.ItemEvent;

            GetComponent<ItemToDisplay>().SellItemControllerScript = this;
        
        }

        public void SellItem()
        {
            if (_itemToDisplay != null && _moneyManagement != null)
            {
                ItemData clickedItemData = _itemToDisplay.ItemData;

                if (clickedItemData.CurrentQuantity > 0)
                {
                    clickedItemData.CurrentQuantity--;
                    _moneyManagement.AddMoney(clickedItemData.SellingPrice);

                    Debug.Log($"Article cliqué : {clickedItemData.Name}, Prix : {clickedItemData.SellingPrice}, Nombre : {clickedItemData.CurrentQuantity}");

                    _itemEvent.InvokeEvent(clickedItemData);

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
        public void OnPointerClick(PointerEventData eventData)
        {
            SellItem();
        }
    }
}
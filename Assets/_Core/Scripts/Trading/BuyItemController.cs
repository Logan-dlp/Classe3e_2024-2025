using AmazingShop.Display;
using AmazingShop.Item;
using AmazingShop.Trading;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AmazingShop.Buy
{
    public class BuyItemController : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Events.ItemEvent _itemEvent;

        private DisplayItemFrame _displayItemFrame;
        private ItemToDisplay _itemToDisplay;
        private MoneyManagement _moneyManagement;

        private void Start()
        {
            _displayItemFrame = GetComponentInParent<DisplayItemFrame>();
            _itemToDisplay = GetComponentInChildren<ItemToDisplay>();
            _moneyManagement = FindObjectOfType<MoneyManagement>();

            _itemEvent = _itemToDisplay.ItemEvent;

            GetComponent<ItemToDisplay>().BuyItemControllerScript = this;
        }


        public void BuyItem()
        {
            if (_displayItemFrame != null && _itemToDisplay != null && _moneyManagement != null)
            {
                ItemData clickedItemData = _itemToDisplay.ItemData;

                if (_moneyManagement.MoneyCount >= clickedItemData.PurchasePrice)
                {
                    if (clickedItemData.CurrentQuantity < clickedItemData.QuantityMax)
                    {
                        clickedItemData.CurrentQuantity++;
                        _moneyManagement.WithdrawMoney(clickedItemData.PurchasePrice);

                        Debug.Log($"Article cliqué : {clickedItemData.Name}, Prix : {clickedItemData.PurchasePrice}, Nombre : {clickedItemData.CurrentQuantity}");

                        _itemEvent.InvokeEvent(clickedItemData);

                        ItemPanelController itemPanelController = GetComponentInChildren<ItemPanelController>();
                        if (itemPanelController != null)
                        {
                            itemPanelController.SetNumberOnPanel(clickedItemData.CurrentQuantity);
                        }

                        _displayItemFrame.DestroyItem(gameObject);
                    }
                    else
                    {
                        Debug.LogWarning("Quantité maximale atteinte pour cet article.");
                    }
                }
                else
                {
                    Debug.LogWarning("Fonds insuffisants pour acheter cet article.");
                }
            }
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            BuyItem();
        }
    }
}
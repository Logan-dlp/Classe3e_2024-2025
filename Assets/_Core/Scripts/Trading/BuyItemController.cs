using AmazingShop.Display;
using AmazingShop.Item;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AmazingShop.Buy
{
    public class BuyItemController : MonoBehaviour, IPointerClickHandler
    {
        private DisplayItemFrame _displayItemFrame;
        private ItemToDisplay _itemToDisplay;

        private void Start()
        {
            _displayItemFrame = GetComponentInParent<DisplayItemFrame>();
            _itemToDisplay = GetComponentInChildren<ItemToDisplay>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_displayItemFrame != null && _itemToDisplay != null)
            {
                ItemData clickedItemData = _itemToDisplay.ItemData;
                Debug.Log($"Article cliqué : {clickedItemData.Name}, Prix : {clickedItemData.PurchasePrice}");

                clickedItemData.CurrentQuantity++;
                Debug.Log(clickedItemData.CurrentQuantity);

                ItemPanelController itemPanelController = GetComponentInChildren<ItemPanelController>();
                if (itemPanelController != null)
                {
                    itemPanelController.SetNumberOnPanel(clickedItemData.CurrentQuantity);
                }

                _displayItemFrame.DestroyItem(gameObject);
            }
        }
    }
}
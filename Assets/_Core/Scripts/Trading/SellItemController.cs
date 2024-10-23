using AmazingShop.Display;
using AmazingShop.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SellItemController : MonoBehaviour, IPointerClickHandler
{
    private ItemToDisplay _itemToDisplay;

    private void Start()
    {
        _itemToDisplay = GetComponentInChildren<ItemToDisplay>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_itemToDisplay != null)
        {
            ItemData clickedItemData = _itemToDisplay.ItemData;

            clickedItemData.CurrentQuantity--;
            Debug.Log($"Article cliqué : {clickedItemData.Name}, Prix : {clickedItemData.SellingPrice}, Nombre : {clickedItemData.CurrentQuantity}");

            ItemPanelController itemPanelController = GetComponentInChildren<ItemPanelController>();
            if (itemPanelController != null)
            {
                itemPanelController.SetNumberOnPanel(clickedItemData.CurrentQuantity);
            }
        }

    }
}

using System;
using AmazingShop.Item;
using TMPro;
using UnityEngine;

public class DisplayItemInfo : MonoBehaviour
{
    private bool _folowCursor;
    public bool FolowCursor
    {
        get => _folowCursor;
        set => _folowCursor = value;
    }

    [SerializeField] private Vector2 _displayOffset = new(25, -25);
    
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private TextMeshProUGUI _quantityMaxText;
    [SerializeField] private TextMeshProUGUI _purchaseText;
    [SerializeField] private TextMeshProUGUI _sellingText;

    private void Update()
    {
        if (_folowCursor)
        {
            transform.position = Input.mousePosition + (Vector3)_displayOffset;
        }
    }

    public void SendItemInfo(ItemData itemData)
    {
        _nameText.text = itemData.Name;
        _descriptionText.text = itemData.Description;
        _quantityMaxText.text = itemData.QuantityMax.ToString();
        _purchaseText.text = itemData.PurchasePrice.ToString();
        _sellingText.text = itemData.SellingPrice.ToString();
    }
}

using AmazingShop.Item;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AmazingShop.Display
{
    public class ItemToDisplay : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _text;
        
        private ItemData _itemData;
        
        public ItemData ItemData
        {
            get => _itemData;
            set => _itemData = value;
        }

        public void SendData()
        {
            _image.sprite = _itemData.Sprite;
            _text.text = _itemData.Name + " " + _itemData.PurchasePrice;
        }
    }
}
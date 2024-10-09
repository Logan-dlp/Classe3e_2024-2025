using AmazingShop.Item;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AmazingShop.Display
{
    public class ItemToDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Events.BoolEvent _triggerDetail;
        [SerializeField] private Image _image;
        
        private ItemData _itemData;
        
        public ItemData ItemData
        {
            get => _itemData;
            set => _itemData = value;
        }

        public void SendData()
        {
            _image.sprite = _itemData.Sprite;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _triggerDetail.InvokeEvent(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _triggerDetail.InvokeEvent(false);
        }
    }
}
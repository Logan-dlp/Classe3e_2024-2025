using System;
using AmazingShop.Item;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AmazingShop.Display
{
    public class ItemToDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
    {
        [SerializeField] private Events.BoolEvent _triggerDetail;
        [SerializeField] private Events.BoolEvent _usePointer;
        [SerializeField] private Events.ItemEvent _itemEvent;
        [SerializeField] private Events.Vector3Event _vectorEvent;
        [SerializeField] private Image _image;
        
        private ItemData _itemData;
        public ItemData ItemData
        {
            get => _itemData;
            set => _itemData = value;
        }
        
        private bool _useMousePointer = false;

        public void SendData()
        {
            _image.sprite = _itemData.Sprite;
        }
        
        public void OnSelect(BaseEventData eventData)
        {
            _usePointer.InvokeEvent(false);
            _triggerDetail.InvokeEvent(true);
            _itemEvent.InvokeEvent(ItemData);
            _vectorEvent.InvokeEvent(transform.position);
        }

        public void OnDeselect(BaseEventData eventData)
        {
            _triggerDetail.InvokeEvent(false);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _usePointer.InvokeEvent(true);
            _triggerDetail.InvokeEvent(true);
            _itemEvent.InvokeEvent(ItemData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _triggerDetail.InvokeEvent(false);
        }

        private void OnDestroy()
        {
            _triggerDetail.InvokeEvent(false);
        }
    }
}
using AmazingShop.Buy;
using AmazingShop.Events;
using AmazingShop.Item;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AmazingShop.Display
{
    public class ItemToDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
    {
        [SerializeField] private BoolEvent _triggerDetail;
        [SerializeField] private BoolEvent _usePointer;
        [SerializeField] private ItemEvent _itemEvent;
        [SerializeField] private Vector3Event _vectorEvent;
        [SerializeField] private Image _image;

        private ItemData _itemData;
        private BuyItemController _buyItemControler;
        private SellItemController _sellItemController;
        private bool _useMousePointer = false;

        public BuyItemController BuyItemControllerScript
        {
            get => _buyItemControler;
            set => _buyItemControler = value;
        }
        
        public SellItemController SellItemControllerScript
        {
            get => _sellItemController;
            set => _sellItemController = value;
        }

        public ItemData ItemData
        {
            get => _itemData;
            set => _itemData = value;
        }

        public ItemEvent ItemEvent 
        { 
            get => _itemEvent;
            set => _itemEvent = value;
        }

        public void BuySellItem()
        {
            if(_buyItemControler != null)
            {
                _buyItemControler.BuyItem();
                return;
            }

            else if(_sellItemController != null)
            {
                _sellItemController.SellItem();
                return;
            }
        }

        public void SendData()
        {
            _image.sprite = _itemData.Sprite;
        }
        
        public void OnSelect(BaseEventData eventData)
        {
            _usePointer.InvokeEvent(false);
            _triggerDetail.InvokeEvent(true);
            ItemEvent.InvokeEvent(ItemData);
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
            ItemEvent.InvokeEvent(ItemData);
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
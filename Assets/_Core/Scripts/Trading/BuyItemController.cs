using AmazingShop.Display;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AmazingShop.Buy
{
    public class BuyItemController : MonoBehaviour, IPointerClickHandler
    {
        private DisplayItemFrame _displayItemFrame;

        private void Start()
        {
            _displayItemFrame = GetComponentInParent<DisplayItemFrame>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_displayItemFrame != null)
            {
                _displayItemFrame.DestroyItem(gameObject);
            }
        }
    }
}
using System;
using AmazingShop.Item;
using UnityEngine;
using UnityEngine.Events;

namespace AmazingShop.Events
{
    public class ItemEventListener : MonoBehaviour
    {
        [SerializeField] private ItemEvent _itemEvent;
        [SerializeField] private UnityEvent<ItemData> _callbacks;

        private void OnEnable()
        {
            _itemEvent.ItemDataAction += InvokeEvent;
        }

        private void OnDisable()
        {
            _itemEvent.ItemDataAction -= InvokeEvent;
        }

        void InvokeEvent(ItemData itemData)
        {
            _callbacks?.Invoke(itemData);
        }
    }
}
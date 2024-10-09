using System;
using AmazingShop.Item;
using UnityEngine;

namespace AmazingShop.Events
{
    public class ItemEvent : ScriptableObject
    {
        public Action<ItemData> ItemDataAction;

        public void InvokeEvent(ItemData itemData)
        {
            ItemDataAction?.Invoke(itemData);
        }
    }
}


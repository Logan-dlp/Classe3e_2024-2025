using System;
using AmazingShop.Item;
using UnityEngine;

namespace AmazingShop.Events
{
    [CreateAssetMenu(fileName = "new_" + nameof(ItemEvent), menuName = "Events/Items")]
    public class ItemEvent : ScriptableObject
    {
        public Action<ItemData> ItemDataAction;

        public void InvokeEvent(ItemData itemData)
        {
            ItemDataAction?.Invoke(itemData);
        }
    }
}


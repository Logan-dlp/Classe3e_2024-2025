using AmazingShop.Item;
using UnityEngine;
using UnityEngine.Events;

namespace AmazingShop.Events
{
    public class ItemEventListener : MonoBehaviour
    {
        [SerializeField] private ItemEvent _itemEvent;
        [SerializeField] private UnityEvent<ItemData> _callbacks;
    }
}
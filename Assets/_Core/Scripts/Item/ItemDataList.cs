using System.Collections.Generic;
using UnityEngine;

namespace AmazingShop.Item
{
    [CreateAssetMenu(fileName = "new_ItemDataList", menuName = "ScriptableObject /new_ItemList")]
    public class ItemListData : ScriptableObject
    {
        [SerializeField] private List<ItemData> _itemDataList;
        public List<ItemData> ItemDataList => _itemDataList;
    }
}

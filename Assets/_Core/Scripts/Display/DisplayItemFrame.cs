using System;
using AmazingShop.Item;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AmazingShop.Display
{
    public class DisplayItemFrame : MonoBehaviour
    {
        [SerializeField] private int _minimumItemToGenerate;
        [SerializeField] private int _maximumItemToGenerate;
        
        [SerializeField] private GameObject _itemFrame;
        [SerializeField] private ItemData[] _itemsDataArray;

        [ContextMenu("Generate Item Frame")]
        public void DebugGenerateItemFrame()
        {
            GenerateItemFrame();
        }
        
        private void GenerateItemFrame()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            
            for (int i = 0; i < Random.Range(_minimumItemToGenerate, _maximumItemToGenerate); i++)
            {
                ItemToDisplay itemFrame = Instantiate(_itemFrame, gameObject.transform).GetComponent<ItemToDisplay>();
                itemFrame.ItemData = _itemsDataArray[Random.Range(0, _itemsDataArray.Length)];
                itemFrame.SendData();
            }
        }
    }   
}
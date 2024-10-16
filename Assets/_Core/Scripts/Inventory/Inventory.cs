using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using AmazingShop.Display;
using AmazingShop.Item;

namespace AmazingShop.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [Header("Initialisation GameObjects")]
        [SerializeField] private GameObject _parentItem;
        [SerializeField] private GameObject _itemPrefab;

        [Header("List of scriptable objects")]
        [SerializeField] private ItemListData _itemDataList;

        [Header("Buttons of inventory")]
        [SerializeField] private Button _nextButton;
        [SerializeField] private Button _previousButton;

        private List<ItemData> _shuffledItems;
        private int _currentPageIndex = 0;
        private const int _itemsPerPage = 10;

        private void Start()
        {
            ShuffleItems();
            DisplayItems();
            _nextButton.onClick.AddListener(DisplayNextItems);
            _previousButton.onClick.AddListener(DisplayPreviousItems);
        }

        private void ShuffleItems()
        {
            _shuffledItems = new List<ItemData>(_itemDataList.ItemDataList);
            for (int i = 0; i < _shuffledItems.Count; i++)
            {
                ItemData temp = _shuffledItems[i];
                int randomIndex = Random.Range(i, _shuffledItems.Count);
                _shuffledItems[i] = _shuffledItems[randomIndex];
                _shuffledItems[randomIndex] = temp;
            }
        }

        private void DisplayItems()
        {
            foreach (Transform child in _parentItem.transform)
            {
                Destroy(child.gameObject);
            }

            int startIndex = _currentPageIndex * _itemsPerPage;
            int endIndex = Mathf.Min(startIndex + _itemsPerPage, _shuffledItems.Count);

            for (int i = startIndex; i < endIndex; i++)
            {
                GameObject itemObject = Instantiate(_itemPrefab, _parentItem.transform);
                ItemData itemData = _shuffledItems[i];

                Image itemImage = itemObject.GetComponent<Image>();
                itemImage.sprite = itemData.Sprite;

                ItemToDisplay itemToDisplay = itemObject.GetComponent<ItemToDisplay>();
                itemToDisplay.ItemData = itemData;
            }

            UpdateButtonStates();
        }

        private void DisplayNextItems()
        {
            if ((_currentPageIndex + 1) * _itemsPerPage < _shuffledItems.Count)
            {
                _currentPageIndex++;
                DisplayItems();
            }
        }

        private void DisplayPreviousItems()
        {
            if (_currentPageIndex > 0)
            {
                _currentPageIndex--;
                DisplayItems();
            }
        }

        private void UpdateButtonStates()
        {
            _nextButton.interactable = (_currentPageIndex + 1) * _itemsPerPage < _shuffledItems.Count;
            _previousButton.interactable = _currentPageIndex > 0;
        }
    }
}

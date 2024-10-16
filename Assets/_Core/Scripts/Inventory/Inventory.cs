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

        private List<ItemData> _itemList;
        private int _currentPageIndex = 0;
        private const int ItemsPerPage = 10;

        private void Start()
        {
            InitializeItems();
            DisplayItems();
            _nextButton.onClick.AddListener(DisplayNextItems);
            _previousButton.onClick.AddListener(DisplayPreviousItems);
        }

        private void InitializeItems()
        {
            _itemList = new List<ItemData>(_itemDataList.ItemDataList);
        }

        private void DisplayItems()
        {
            foreach (Transform child in _parentItem.transform)
            {
                Destroy(child.gameObject);
            }

            int startIndex = _currentPageIndex * _itemsPerPage;
            int endIndex = Mathf.Min(startIndex + _itemsPerPage, _itemList.Count);

            for (int i = startIndex; i < endIndex; i++)
            {
                GameObject itemObject = Instantiate(_itemPrefab, _parentItem.transform);
                ItemData itemData = _itemList[i];

                Image itemImage = itemObject.GetComponent<Image>();
                itemImage.sprite = itemData.Sprite;

                ItemToDisplay itemToDisplay = itemObject.GetComponent<ItemToDisplay>();
                itemToDisplay.ItemData = itemData;
            }

            UpdateButtonStates();
        }

        private void DisplayNextItems()
        {
            if ((_currentPageIndex + 1) * _itemsPerPage < _itemList.Count)
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
            _nextButton.interactable = (_currentPageIndex + 1) * _itemsPerPage < _itemList.Count;
            _previousButton.interactable = _currentPageIndex > 0;
        }
    }
}
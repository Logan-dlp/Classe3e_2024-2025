using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using AmazingShop.Display;
using AmazingShop.Item;

namespace AmazingShop.Inventory
{
    public class DisplayInventoryItem : MonoBehaviour
    {
        [Header("Initialisation GameObjects")]
        [SerializeField] private GameObject _parentItem;
        [SerializeField] private GameObject _itemPrefab;

        [Header("List of scriptable objects")]
        [SerializeField] private ItemListData _itemDataList;

        [Header("Buttons of inventory")]
        [SerializeField] private Button _nextButton;
        [SerializeField] private Button _previousButton;

        [SerializeField] private bool _activePanel;
        
        private int _currentPageIndex;
        private const int ItemsPerPage = 10;
        
        private Dictionary<ItemData, int> _itemInventoryDictionary = new();
        private List<ItemData> _itemsInventoryList = new();

        private void Start()
        {
            InitializeItems();
            DisplayItems();
            _nextButton.onClick.AddListener(DisplayNextItems);
            _previousButton.onClick.AddListener(DisplayPreviousItems);
        }

        private void InitializeItems()
        {
            foreach (ItemData itemData in _itemDataList.ItemDataList)
            {
                if (_itemInventoryDictionary.ContainsKey(itemData))
                {
                    _itemInventoryDictionary[itemData] = _itemInventoryDictionary[itemData] + 1;
                }
                else
                {
                    _itemInventoryDictionary.Add(itemData, 1);
                    _itemsInventoryList.Add(itemData);
                }
            }
        }

        private void DisplayItems()
        {
            foreach (Transform child in _parentItem.transform)
            {
                Destroy(child.gameObject);
            }

            int startIndex = _currentPageIndex * ItemsPerPage;
            int endIndex = Mathf.Min(startIndex + ItemsPerPage, _itemsInventoryList.Count);

            for (int i = startIndex; i < endIndex; i++)
            {
                GameObject itemObject = Instantiate(_itemPrefab, _parentItem.transform);
                ItemData itemData = _itemsInventoryList[i];

                Image itemImage = itemObject.GetComponent<Image>();
                itemImage.sprite = itemData.Sprite;

                ItemToDisplay itemToDisplay = itemObject.GetComponent<ItemToDisplay>();
                itemToDisplay.ItemData = itemData;

                if (_activePanel)
                {
                    ItemPanelController panelController = itemObject.GetComponent<ItemPanelController>();
                    panelController.ActivatePanel();
                    panelController.SetNumberOnPanel(_itemInventoryDictionary[itemData]);
                }
            }

            UpdateButtonStates();
        }

        private void DisplayNextItems()
        {
            if ((_currentPageIndex + 1) * ItemsPerPage < _itemsInventoryList.Count)
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
            _nextButton.interactable = (_currentPageIndex + 1) * ItemsPerPage < _itemsInventoryList.Count;
            _previousButton.interactable = _currentPageIndex > 0;
        }
    }
}
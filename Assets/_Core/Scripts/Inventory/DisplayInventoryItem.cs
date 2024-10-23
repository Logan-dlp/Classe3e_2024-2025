using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using AmazingShop.Display;
using AmazingShop.Item;

namespace AmazingShop.Inventory
{
    public class DisplayInventoryItem : MonoBehaviour
    {
        private const int ItemsPerPage = 10;

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
        
        private Dictionary<ItemData, int> _itemInventoryDictionary = new();
        private List<ItemData> _itemsInventoryList = new();

        private void Start()
        {
            _nextButton.onClick.AddListener(DisplayNextItems);
            _previousButton.onClick.AddListener(DisplayPreviousItems);
        }

        private void OnEnable()
        {
            _currentPageIndex = 0;
            
            InitializeItems();
            DisplayItems();
        }

        private void OnDisable()
        {
            foreach (Transform child in _parentItem.transform)
            {
                Destroy(child.gameObject);
            }
        }

        private void InitializeItems()
        {
            _itemInventoryDictionary.Clear();
            _itemsInventoryList.Clear();
            
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
                ItemData itemData = _itemsInventoryList[i];

                GameObject itemObject = Instantiate(_itemPrefab, _parentItem.transform);
                
                if (itemObject.TryGetComponent<Image>(out Image imageComponent))
                {
                    imageComponent.sprite = itemData.Sprite;
                }
                else
                {
                    Debug.LogError("Not find Image Component !");
                }

                if (itemObject.TryGetComponent<ItemToDisplay>(out ItemToDisplay itemToDisplay))
                {
                    itemToDisplay.ItemData = itemData;
                }

                if (_activePanel && itemObject.TryGetComponent<ItemPanelController>(out ItemPanelController itemPanelController))
                {
                    itemPanelController.ActivatePanel();
                    itemPanelController.SetNumberOnPanel(_itemInventoryDictionary[itemData]);
                }else if (_activePanel)
                {
                    Debug.LogError("Not find ItemPanelController Component !");
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
            if((_currentPageIndex + 1) * ItemsPerPage > _itemsInventoryList.Count)
            {
                _previousButton.Select();
            }
        }

        private void DisplayPreviousItems()
        {
            if (_currentPageIndex > 0)
            {
                _currentPageIndex--;
                DisplayItems();
            }
            if(_currentPageIndex == 0)
            {
                _nextButton.Select();
            }
        }

        private void UpdateButtonStates()
        {
            _nextButton.interactable = (_currentPageIndex + 1) * ItemsPerPage < _itemsInventoryList.Count;
            _previousButton.interactable = _currentPageIndex > 0;
        }
    }
}
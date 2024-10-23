using System;
using AmazingShop.Events;
using UnityEngine;

namespace AmazingShop.Trading
{
    public class MoneyManagement : MonoBehaviour
    {
        [SerializeField] private IntEvent _moneyEvent;
        
        private int _moneyCount = 100;
        public int MoneyCount => _moneyCount;

        private void Start()
        {
            RefreshMoney();
        }

        public void AddMoney(int moneyToAdd)
        {
            if (moneyToAdd < 0)
            {
                Debug.LogWarning("Please note that the value added to the currency is negative.");
            }
            _moneyCount += moneyToAdd;
            
            RefreshMoney();
        }

        public void WithdrawMoney(int moneyToRemove)
        {
            if (moneyToRemove < 0)
            {
                Debug.LogWarning("Please note that the value added to the currency is negative.");
            }
            _moneyCount -= moneyToRemove;
            if (_moneyCount < 0)
            {
                _moneyCount = 0;
            }
            
            RefreshMoney();
        }

        private void RefreshMoney()
        {
            _moneyEvent?.InvokeEvent(_moneyCount);
        }
    }
}
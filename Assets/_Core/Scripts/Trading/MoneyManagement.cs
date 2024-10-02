using UnityEngine;

namespace Trading
{
    public class MoneyManagement : MonoBehaviour
    {
        private int _moneyCount;
        public int MoneyCount => _moneyCount;

        public void AddMoney(int moneyToAdd)
        {
            if (moneyToAdd < 0)
            {
                Debug.LogWarning("Please note that the value added to the currency is negative.");
            }
            _moneyCount += moneyToAdd;
        }

        public void WithdrawMoney(int moneyToRemove)
        {
            if (moneyToRemove < 0)
            {
                Debug.LogWarning("Please note that the value added to the currency is negative.");
            }
            _moneyCount -= moneyToRemove;
            if (_moneyCount < 0) _moneyCount = 0;
        }
    }
}
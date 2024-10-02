using UnityEngine;

namespace Trading
{
    public class MoneyManagement : MonoBehaviour
    {
        private int _moneyCount;
        public int MoneyCount => _moneyCount;

        public void AddMoney(int moneyToAdd)
        {
            _moneyCount += moneyToAdd;
        }

        public void WithdrawMoney(int moneyToRemove)
        {
            _moneyCount -= moneyToRemove;
            if (_moneyCount < 0) _moneyCount = 0;
        }
    }
}
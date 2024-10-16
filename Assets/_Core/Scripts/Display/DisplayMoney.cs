using AmazingShop.Trading;
using TMPro;
using UnityEngine;

namespace AmazingShop.Display
{
    public class DisplayMoney : MonoBehaviour
    {
        private TMP_Text _moneyTMPText;
        private MoneyManagement _moneyManagement;

        private void Start()
        {
            _moneyTMPText = GetComponent<TMP_Text>();
            _moneyManagement = FindObjectOfType<MoneyManagement>();
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _moneyTMPText.text = "AmazingCoins : " + _moneyManagement.MoneyCount;
        }
    }
}

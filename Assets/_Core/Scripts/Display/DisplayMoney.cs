using AmazingShop.Trading;
using TMPro;
using UnityEngine;

namespace AmazingShop.Display
{
    public class DisplayMoney : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyText;

        public void Display(int value)
        {
            _moneyText.text = $"Money: {value}";
        }
    }
}

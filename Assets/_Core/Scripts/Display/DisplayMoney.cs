using AmazingShop.Trading;
using TMPro;
using UnityEngine;

namespace AmazingShop.Display
{
    public class DisplayMoney : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void Display(int value)
        {
            _text.text = $"Money: {value}";
        }
    }
}

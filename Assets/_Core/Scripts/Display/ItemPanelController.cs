using TMPro;
using UnityEngine;

namespace AmazingShop.Display
{
    public class ItemPanelController : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private TextMeshProUGUI _numberInPanel;

        public void ActivatePanel()
        {
            _panel.SetActive(true);
        }

        public void SetNumberOnPanel(int number)
        {
            _numberInPanel.text = number.ToString();
        }
    }
}
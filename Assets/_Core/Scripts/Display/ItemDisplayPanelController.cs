using AmazingShop.Events;
using UnityEngine;

namespace AmazingShop.Display
{
    public class ItemDisplayPanelController : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private BoolEvent _togglePanelEvent;
        [SerializeField] private GameObject _inventory;
        [SerializeField] private GameObject _sell;

        private void OnEnable()
        {
            _togglePanelEvent.BoolAction += OnTogglePanel;
            CheckAndTogglePanel();
        }

        private void OnDisable()
        {
            _togglePanelEvent.BoolAction -= OnTogglePanel;
        }

        private void OnTogglePanel(bool isActive)
        {
            _panel.SetActive(isActive);
        }

        private void CheckAndTogglePanel()
        {
            if ((_inventory != null && IsInHierarchy(_inventory)) || (_sell != null && IsInHierarchy(_sell)))
            {
                _togglePanelEvent.InvokeEvent(true);
            }
            else
            {
                _togglePanelEvent.InvokeEvent(false);
            }
        }

        private bool IsInHierarchy(GameObject parent)
        {
            return transform.IsChildOf(parent.transform) || parent.transform.IsChildOf(transform);
        }
    }
}

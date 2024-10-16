using AmazingShop.Events;
using UnityEngine;

namespace AmazingShop.Display
{
    public class ItemDisplayPanelController : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private BoolEvent togglePanelEvent;

        private void OnEnable()
        {
            togglePanelEvent.BoolAction += OnTogglePanel;
            CheckAndTogglePanel();
        }

        private void OnDisable()
        {
            togglePanelEvent.BoolAction -= OnTogglePanel;
        }

        private void OnTogglePanel(bool isActive)
        {
            panel.SetActive(isActive);
        }

        private void CheckAndTogglePanel()
        {
            GameObject inventory = GameObject.FindGameObjectWithTag("Inventory");
            GameObject sell = GameObject.FindGameObjectWithTag("Sell");

            if ((inventory != null && IsInHierarchy(inventory)) || (sell != null && IsInHierarchy(sell)))
            {
                togglePanelEvent.InvokeEvent(true);
            }
            else
            {
                togglePanelEvent.InvokeEvent(false);
            }
        }

        private bool IsInHierarchy(GameObject parent)
        {
            return transform.IsChildOf(parent.transform) || parent.transform.IsChildOf(transform);
        }
    }
}

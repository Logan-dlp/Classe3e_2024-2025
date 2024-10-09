using UnityEngine;
using UnityEngine.Events;

namespace AmazingShop.Events
{
    public class BoolEventListener : MonoBehaviour
    {
        [SerializeField] private BoolEvent _boolEvent;
        [SerializeField] private UnityEvent<bool> _callbacks;

        private void OnEnable()
        {
            _boolEvent.BoolAction += InvokeEvent;
        }

        private void InvokeEvent(bool value)
        {
            _callbacks?.Invoke(value);
        }
    }
}
using System;
using UnityEngine;
using UnityEngine.Events;

namespace AmazingShop.Events
{
    public class IntEventListener : MonoBehaviour
    {
        [SerializeField] private IntEvent _intEvent;
        [SerializeField] private UnityEvent<int> _callbacks;

        private void OnEnable()
        {
            _intEvent.InAction += InvokeEvent;
        }

        private void OnDisable()
        {
            _intEvent.InAction -= InvokeEvent;
        }

        private void InvokeEvent(int value)
        {
            _callbacks?.Invoke(value);
        }
    }
}
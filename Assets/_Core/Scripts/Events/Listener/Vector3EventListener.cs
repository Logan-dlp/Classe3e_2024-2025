using System.Collections;
using System.Collections.Generic;
using AmazingShop.Item;
using UnityEngine;
using UnityEngine.Events;

namespace AmazingShop.Events
{
    public class Vector3EventListener : MonoBehaviour
    {
        [SerializeField] private Vector3Event _vector3Event;
        [SerializeField] private UnityEvent<Vector3> _callbacks;

        private void OnEnable()
        {
            _vector3Event.ActionVector3 += InvokeEvent;
        }

        private void OnDisable()
        {
            _vector3Event.ActionVector3 -= InvokeEvent;
        }

        void InvokeEvent(Vector3 vector)
        {
            _callbacks?.Invoke(vector);
        }
    }
}

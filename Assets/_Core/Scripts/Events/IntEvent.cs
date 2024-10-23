using System;
using UnityEngine;

namespace AmazingShop.Events
{
    [CreateAssetMenu(fileName = "new_" + nameof(IntEvent), menuName = "Events/Int")]
    public class IntEvent : ScriptableObject
    {
        public Action<int> IntAction;

        public void InvokeEvent(int value)
        {
            IntAction?.Invoke(value);
        }
    }
}
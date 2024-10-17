using System;
using UnityEngine;

namespace AmazingShop.Events
{
    [CreateAssetMenu(fileName = "new_" + nameof(IntEvent), menuName = "Events/Int")]
    public class IntEvent : ScriptableObject
    {
        public Action<int> InAction;

        public void InvokeEvent(int value)
        {
            InAction?.Invoke(value);
        }
    }
}
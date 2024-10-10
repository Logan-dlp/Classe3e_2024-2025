using System;
using UnityEngine;

namespace AmazingShop.Events
{
    [CreateAssetMenu(fileName = "new_" + nameof(BoolEvent), menuName = "Events/Bool")]
    public class BoolEvent : ScriptableObject
    {
        public Action<bool> BoolAction;

        public void InvokeEvent(bool value)
        {
            BoolAction?.Invoke(value);
        }
    }
}
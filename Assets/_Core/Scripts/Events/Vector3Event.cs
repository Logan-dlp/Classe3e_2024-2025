using System;
using UnityEngine;

namespace AmazingShop.Events
{
    [CreateAssetMenu(fileName = "new_" + nameof(Vector3Event), menuName = "Events/Vector 3")]
    public class Vector3Event : ScriptableObject
    {
        public Action<Vector3> ActionVector3;

        public void InvokeEvent(Vector3 vector)
        {
            ActionVector3?.Invoke(vector);
        }
    }
}
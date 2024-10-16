using UnityEngine;

namespace AmazingShop.Utility
{
    public class DestroyAllChildren : MonoBehaviour
    {
        public void DestroyChildren()
        {
            foreach (Transform child in gameObject.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }

}

using UnityEngine;
using UnityEngine.Serialization;

namespace AmazingShop.Display
{ 
    public class ChangeUIScreen : MonoBehaviour
    {
        [SerializeField] private Canvas _canvasToClose;
        
        public void ChangeScreen(Canvas _canvasToOpen)
        {
            _canvasToClose.enabled = !_canvasToClose.enabled;
            _canvasToOpen.enabled = !_canvasToOpen.enabled;
        }
    }
}

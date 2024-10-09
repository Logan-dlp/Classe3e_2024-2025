using UnityEngine;
using UnityEngine.EventSystems;

public class DisplayItemInfo : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerClick);
    }
}

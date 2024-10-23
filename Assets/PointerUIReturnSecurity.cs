using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PointerUIReturnSecurity : MonoBehaviour
{
    [SerializeField] private Button _returnButton;
    private EventSystem _eventSystem;

    private void Start()
    {
        _eventSystem = FindObjectOfType<EventSystem>();
    }

    void Update()
    {
        if( _eventSystem.currentSelectedGameObject == null )
        {
            _returnButton.Select();
            Debug.Log(_eventSystem.currentSelectedGameObject);
        }
    }
}

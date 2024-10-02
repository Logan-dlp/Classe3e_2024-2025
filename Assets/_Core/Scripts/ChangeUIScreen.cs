using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{ 
    public class ChangeUIScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _panelToClose;
        
        public void ChangeScreen(GameObject _sceneToOpen)
        {
            _panelToClose.SetActive(false);
            _sceneToOpen.SetActive(true);
        }
    }
}

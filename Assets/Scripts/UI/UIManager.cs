using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace DefaultNamespace.UI
{
    public class UIManager : Singleton<UIManager>
    {
        public static GameObject equipCross;

        private void Awake()
        {
            equipCross = GameObject.Find("UIEquipCross");
        }

        public static void Enable(GameObject uiObject)
        {
            uiObject.SetActive(true);
            uiObject.GetComponent<UIElement>().OnEnable();
        }

        public static void Disable(GameObject uiObject)
        {
            uiObject.SetActive(false);
            uiObject.GetComponent<UIElement>().OnDisable();

        }
        
    }
}
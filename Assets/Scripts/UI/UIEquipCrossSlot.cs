using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

namespace DefaultNamespace.UI
{
    public class UIEquipCrossSlot : MonoBehaviour
    {
        private Animator animator;
        private Image image;
        
        private UIEquipCrossSlot _nextSlot;
        private UIEquipCrossSlot _prevSlot;
        
        public UIEquipCrossSlot NextSlot {get { return _nextSlot; } set { _nextSlot = value; } }
        public UIEquipCrossSlot PrevSlot {get { return _prevSlot; } set { _prevSlot = value; } }

        public UIEquipCrossSlot(UIEquipCrossSlot nextSlot, UIEquipCrossSlot prevSlot)
        {
            _nextSlot = nextSlot;
            _prevSlot = prevSlot;
        }

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        public void OnSelect()
        {
            image.color = Color.cyan;
        }

        public void OnDeselect()
        {
            image.color = Color.white;
        }
    }
}
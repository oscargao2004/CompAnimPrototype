using System;
using System.Collections.Generic;
using DefaultNamespace.PlayerScripts;
using UnityEngine;

namespace DefaultNamespace.UI
{
    public class UIEquipCross : UIElement
    {
        private int _horizontalSlotIndex;
        private int _verticalSlotIndex;

        private UIEquipCrossSlot _currentSlot;

        private float _scrollWheelValue;

        //[SerializeField] private List<GameObject> horizontalSlotObjs;
        //[SerializeField] private List<GameObject> verticalSlotsObjs;
        
        [SerializeField] List<UIEquipCrossSlot> horizontalEquipCrossSlots;
        [SerializeField] List<UIEquipCrossSlot> verticalEquipCrossSlots;

        private void Awake()
        {
            InitializeSlots();
            gameObject.SetActive(false);
        }

        private void Start()
        {
        }

        private void Update()
        {
            HandleHorizontalSlotSelection();
            HandleVerticalSlotSelection();
        }
        
        void InitializeSlots()
        {
            for (int i = 0; i < horizontalEquipCrossSlots.Count; i++) //initialize horizontal slots
            {
                if (i == 0) //if at the start of the list
                {
                    horizontalEquipCrossSlots[i].PrevSlot = horizontalEquipCrossSlots[i];
                    horizontalEquipCrossSlots[i].NextSlot = horizontalEquipCrossSlots[i + 1];
                    
                }

                else if (i == horizontalEquipCrossSlots.Count - 1) //if at the end of the list
                {
                    horizontalEquipCrossSlots[i].PrevSlot = horizontalEquipCrossSlots[i - 1];
                    horizontalEquipCrossSlots[i].NextSlot = horizontalEquipCrossSlots[i];
                }

                else //if after and before start and end of list
                {
                    horizontalEquipCrossSlots[i].PrevSlot = horizontalEquipCrossSlots[i - 1];
                    horizontalEquipCrossSlots[i].NextSlot = horizontalEquipCrossSlots[i + 1];
                }
            }
            
            for (int i = 0; i < verticalEquipCrossSlots.Count; i++) //initialize vertical slots
            {
                if (i == 0) //if at the start of the list
                {
                    verticalEquipCrossSlots[i].PrevSlot = verticalEquipCrossSlots[i];
                    verticalEquipCrossSlots[i].NextSlot = verticalEquipCrossSlots[i + 1];
                    
                }

                else if (i == verticalEquipCrossSlots.Count - 1) //if at the end of the list
                {
                    verticalEquipCrossSlots[i].PrevSlot = verticalEquipCrossSlots[i - 1];
                    verticalEquipCrossSlots[i].NextSlot = verticalEquipCrossSlots[i];
                }

                else //if after and before start and end of list
                {
                    verticalEquipCrossSlots[i].PrevSlot = verticalEquipCrossSlots[i - 1];
                    verticalEquipCrossSlots[i].NextSlot = verticalEquipCrossSlots[i + 1];
                }
            }
        }

        void SetCurrentSlot(UIEquipCrossSlot slot)
        {
            if (_currentSlot)
            {
                _currentSlot.OnDeselect();
            }
            _currentSlot = slot;
            _currentSlot.OnSelect();
        }

        void HandleHorizontalSlotSelection()
        {
            //horizontal slot selection
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SetCurrentSlot(horizontalEquipCrossSlots[0]);
                _verticalSlotIndex = 0;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SetCurrentSlot(horizontalEquipCrossSlots[1]);
                _verticalSlotIndex = 0;

            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SetCurrentSlot(horizontalEquipCrossSlots[2]);
                _verticalSlotIndex = 0;

            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                SetCurrentSlot(horizontalEquipCrossSlots[3]);
                _verticalSlotIndex = 0;

            }
        }
        void HandleVerticalSlotSelection()
        {
            //vertical slot selection
            _scrollWheelValue = Input.GetAxisRaw("Mouse ScrollWheel");
            if (_scrollWheelValue > 0)
            {
                _horizontalSlotIndex = 0;

                _verticalSlotIndex += 1;
                if (_verticalSlotIndex >= verticalEquipCrossSlots.Count)
                {
                    _verticalSlotIndex = verticalEquipCrossSlots.Count - 1;
                }
                SetCurrentSlot(verticalEquipCrossSlots[_verticalSlotIndex]);
                PlayerAnimationManager.PlayEquipItem();
                
            }
            if (_scrollWheelValue < 0)
            {
                _horizontalSlotIndex = 0;

                _verticalSlotIndex -= 1;
                if (_verticalSlotIndex <= 0)
                {
                    _verticalSlotIndex = 0;
                }
                SetCurrentSlot(verticalEquipCrossSlots[_verticalSlotIndex]);
                PlayerAnimationManager.PlayEquipItem();

            }
        }
        
        
        public override void OnEnable()
        {
            
        }

        public override void OnDisable()
        {
            //reset horizontal and vertical indices
            _horizontalSlotIndex = 0;
            _verticalSlotIndex = 0;
            
            //deselect current slot
            _currentSlot.OnDeselect();
            SetCurrentSlot(null);
        }
    }
}
using System;
using DefaultNamespace.UI;
using PlayerScripts.PlayerStates;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement stats")]
    
    [SerializeField] float moveSpeed = 5f;
    
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }

    private PlayerBaseState _currentBaseState;
    private bool _allowMovement;
    private Vector3 movementVector;
    private static PlayerStateManager _playerStateManager;
    
    
    private void Awake()
    {
        _playerStateManager = GetComponent<PlayerStateManager>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        //temporary function to activate equip cros UI
        if (Input.GetKeyDown(KeyCode.Tab))
        { 
            UIManager.Enable(UIManager.equipCross);
        }
    }
    
    public void ToggleAllowMovement(bool val)
    {
        _allowMovement = val;
    }

}

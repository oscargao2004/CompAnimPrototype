using System;
using System.Resources;
using UnityEngine;

namespace PlayerScripts.PlayerStates
{
    public class PlayerStateManager : MonoBehaviour
    {
        PlayerBaseState _currentState;
        public PlayerBaseState idleState;
        public PlayerBaseState jogState;
        public PlayerBaseState meleeFinisherState;
        public PlayerBaseState dodgeState;

        public Animator animator;

        private void Awake()
        {
            idleState = new PlayerIdleState(this);
            jogState = new PlayerJogState(this);
            meleeFinisherState = new PlayerMeleeFinisherState(this);
            dodgeState= new PlayerDodgeState(this);
        }

        private void Start()
        {
            _currentState = idleState;
            
            _currentState.OnEnter();
        }

        private void Update()
        {
            _currentState.OnUpdate();
        }

        public void SwitchState(PlayerBaseState newBaseState)
        {
            _currentState.OnExit();
            _currentState = newBaseState;
            _currentState.OnEnter();
        }

        public void SetState(PlayerBaseState state)
        {
            _currentState = state;
        }
        
    }
}
using UnityEngine;

namespace PlayerScripts.PlayerStates
{
    public class PlayerJogState : PlayerBaseState
    {
        private Vector3 _movementVector;
        private static PlayerController _playerController;

        public PlayerJogState(PlayerStateManager ctx) : base(ctx)
        {
        }

        public override void OnEnter()
        {
            Debug.Log("entering jog state");
            if (_playerController == null)
                _playerController = ctx.gameObject.GetComponent<PlayerController>();
            
            ctx.animator.SetBool("isWalking", true);
            
        }

        public override void OnUpdate()
        {
            HandleMovement();
            HandleRotation();
        }

        public override void OnExit()
        {
            Debug.Log("exiting jog state");
            ctx.animator.SetBool("isWalking", false);
        }
        
        void HandleMovement()
        {
            _movementVector = ctx.transform.rotation * new  Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
            ctx.transform.position += _movementVector * Time.deltaTime * _playerController.MoveSpeed;

            if (_movementVector == Vector3.zero)
            {
                ctx.SwitchState(ctx.idleState);
            }
        }
        
        void HandleRotation()
        {
            ctx.transform.forward = new Vector3(Camera.main.transform.forward.x, ctx.transform.forward.y, Camera.main.transform.forward.z);
        }
    }
}
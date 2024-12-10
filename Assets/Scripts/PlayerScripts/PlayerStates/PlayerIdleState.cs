using UnityEngine;

namespace PlayerScripts.PlayerStates
{
    public class PlayerIdleState : PlayerBaseState
    {
        public PlayerIdleState(PlayerStateManager ctx) : base(ctx)
        {
        }

        public override void OnEnter()
        {
            Debug.Log("entering idle state");
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) ||
                Input.GetKeyDown(KeyCode.D))
            {
                ctx.SwitchState(ctx.jogState);
            }
        }

        public override void OnExit()
        {
            Debug.Log("exiting idle state");
        }
    }
}
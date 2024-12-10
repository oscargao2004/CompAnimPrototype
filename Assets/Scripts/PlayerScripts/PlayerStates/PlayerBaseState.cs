using UnityEngine;

namespace PlayerScripts.PlayerStates
{
    public abstract class PlayerBaseState
    {
        protected PlayerStateManager ctx;
        public PlayerBaseState(PlayerStateManager manager)
        {
            ctx = manager;
        }
        public abstract void OnEnter();
        public abstract void OnUpdate();
        public abstract void OnExit();

    }
}
using System;
using UnityEngine;

namespace DefaultNamespace.PlayerScripts
{
    public class PlayerAnimationManager : Singleton<PlayerAnimationManager>
    {
        private static Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public static void PlayEquipItem()
        {
            animator.SetTrigger("SelectItem");
        }
    }
}
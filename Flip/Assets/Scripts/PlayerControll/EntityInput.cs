using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flip.PlayerControll
{
    public class EntityInput : MonoBehaviour
    {
        #region 字段

        [Header("Boolean")]
        public bool JumpPressed;
        public bool CrouchPressed;
        public bool ClimbPressed;
        public bool IsGrounded;
        public bool IsJumping;
        public bool IsAccelerating;
        public bool CanJump;
        public bool RushJumping;
        public bool NormalJumping;
        public bool CanControl = true;
        public bool IsPushing;
        public bool IsInvincible;
        [Space]
        [Header("Int")]
        public int JumpCount;
        [Space]
        [Header("Float")]
        public float horizontalMove;
        public float InvincibleTimer;
        [Space]
        [Header("Raycast Info")]
        public RaycastHit2D[] Object;

        #endregion
    }
}

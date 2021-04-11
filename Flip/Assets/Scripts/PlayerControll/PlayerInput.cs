using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flip.PlayerControll
{
    public class PlayerInput : MonoBehaviour
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
        public bool CanClimb;
        public bool RushJumping;
        public bool NormalJumping;
        [Space]
        [Header("Int")]
        public int JumpCount;

        private RaycastHit2D[] hitInfo;

        #endregion

        #region Unity回调

        void Update()
        {
            SwitchMovement();
        }

        #endregion

        #region 方法

        public void SwitchMovement()
        {
            //跳跃
            if (Input.GetButtonDown("Jump") && JumpCount > 0)
            {
                JumpPressed = true;

                if (JumpPressed)
                {
                    if (IsAccelerating)
                    {
                        RushJumping = true;
                    }
                    else
                    {
                        NormalJumping = true;
                    }
                }
            }
            else
            {
                JumpPressed = false;
                RushJumping = false;
                NormalJumping = false;
            }

            //加速
            if (Input.GetKey(KeyCode.LeftShift) && IsGrounded)
            {
                IsAccelerating = true;
            }
            else
            {
                IsAccelerating = false;
            }

            //蹲下
            if (Input.GetKeyDown(KeyCode.S))
            {
                CrouchPressed = true;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                CrouchPressed = false;
            }

        }

        #endregion
    }
}

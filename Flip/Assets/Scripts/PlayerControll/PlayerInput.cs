using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flip.PlayerControll
{
    public class PlayerInput : MonoBehaviour
    {
        #region �ֶ�

        public bool JumpPressed;
        public bool CrouchPressed;
        public int JumpCount;
        public bool IsGrounded;
        public bool IsJumping;
        public bool IsAccelerating;
        public bool IsCrouching;
        public bool CanJump;

        #endregion

        #region Unity�ص�
        private void Update()
        {
            SwitchMovement();
        }

        #endregion

        #region ����

        public void SwitchMovement()
        {
            if (Input.GetButtonDown("Jump") && JumpCount > 0)
            {
                JumpPressed = true;
            }

            if (Input.GetKey(KeyCode.LeftShift) && IsGrounded)
            {
                IsAccelerating = true;
            }
            else
            {
                IsAccelerating = false;
            }

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

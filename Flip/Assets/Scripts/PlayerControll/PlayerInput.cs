using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flip.Module;

namespace Flip.PlayerControll
{
    public class PlayerInput : BaseSingletonWithMono<PlayerInput>
    {
        private EntityInput entityInput;

        #region Unity回调

        void Awake()
        {
            entityInput = GetComponent<EntityInput>();
        }

        void Update()
        {
            if (CancelControl())
            {
                return;
            }
            else if (AllowControl())
            {
                SwitchMovement();
            }
        }

        #endregion

        #region 方法

        public void SwitchMovement()
        {
            //跳跃
            if (Input.GetButtonDown("Jump") && entityInput.JumpCount > 0)
            {
                entityInput.JumpPressed = true;

                if (entityInput.JumpPressed)
                {
                    if (entityInput.IsAccelerating)
                    {
                        entityInput.RushJumping = true;
                    }
                    else
                    {
                        entityInput.NormalJumping = true;
                    }
                }
            }
            else
            {
                entityInput.JumpPressed = false;
                entityInput.RushJumping = false;
                entityInput.NormalJumping = false;
            }

            //加速
            if (Input.GetKey(KeyCode.LeftShift) && entityInput.IsGrounded)
            {
                entityInput.IsAccelerating = true;
            }
            else
            {
                entityInput.IsAccelerating = false;
            }

            //蹲下
            if (Input.GetKeyDown(KeyCode.S))
            {
                entityInput.CrouchPressed = true;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                entityInput.CrouchPressed = false;
            }

            //推箱子
            if (Input.GetKey(KeyCode.F))
            {
                entityInput.IsPushing = true;
            }
            else
            {
                entityInput.IsPushing = false;
            }
        }

        //禁止玩家操作
        public bool CancelControl()
        {
            return entityInput.CanControl = false;
        }

        //开启玩家操作
        public bool AllowControl()
        {
            return entityInput.CanControl = true;
        }

        #endregion
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flip.Module;
using Flip.Interact;

namespace Flip.PlayerControll
{
    public class PlayerInput : BaseSingletonWithMono<PlayerInput>
    {
        #region  字段
        private EntityInput entityInput;
        private PushObject pushObject;

        #endregion

        #region Unity回调

        void Awake()
        {
            entityInput = GetComponent<EntityInput>();
            pushObject = GetComponent<PushObject>();
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

            entityInput.horizontalMove = Input.GetAxisRaw("Horizontal");
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
            if (pushObject.IsPushing)
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

        ////玩家身前2单位，从天上射一条射线下来，碰到的ground与player的高度差大于3，就可以翻越（区别于大跳）
        //public void OverObstacle()
        //{
        //    entityInput.Object=Physics2D.RaycastAll(new Vector2(transform.localPosition.x+2f,500f),Vector2.down,)
        //}

        #endregion
    }
}

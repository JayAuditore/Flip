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
        private Renderer render;
        private EntityMove entityMove;

        #endregion

        #region Unity回调

        void Awake()
        {
            entityInput = GetComponent<EntityInput>();
            pushObject = GetComponent<PushObject>();
            render = GetComponent<Renderer>();
            entityMove = GetComponent<EntityMove>();
        }

        void Update()
        {
            if (!entityInput.CanControl)
            {
                return;
            }
            else
            {
                SwitchMovement();
            }

            if (entityInput.IsInvincible)
            {
                Flash();
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

        /// <summary>
        /// 禁止玩家操作
        /// </summary>
        /// <param name="state">是否开启</param>
        /// <returns>开启或关闭</returns>
        public bool CanControl(bool state)
        {
            return entityInput.CanControl = state;
        }

        /// <summary>
        /// 碰到怪物后的反应
        /// </summary>
        /// <param name="collision">碰撞的物体</param>
        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                GetInvincible();
                Physics2D.IgnoreCollision(this.GetComponent<CapsuleCollider2D>(), collision.collider, true);
                entityMove.SlowDownTimer = 0;

                // 弹开
                if (transform.position.x - collision.transform.position.x < 0f)
                {
                    Debug.Log("1");
                    transform.Translate(-2f, 0f, 0f);
                }
                else
                {
                    Debug.Log("2");
                    transform.Translate(2f, 0f, 0f);

                }
            }
        }

        /// <summary>
        /// 变成无敌状态
        /// </summary>
        public void GetInvincible()
        {
            entityInput.IsInvincible = true;
        }

        /// <summary>
        /// 受伤之后闪烁
        /// </summary>
        public void Flash()
        {
            entityInput.InvincibleTimer += Time.deltaTime;

            if (entityInput.InvincibleTimer < 1.5f)
            {
                float _timer = entityInput.InvincibleTimer % 0.075f;
                render.enabled = _timer > 0.0375f;
            }
            else
            {
                render.enabled = true;
                entityInput.IsInvincible = false;
                entityInput.InvincibleTimer = 0;
                Physics2D.IgnoreCollision(this.GetComponent<CapsuleCollider2D>(), GameObject.FindGameObjectWithTag("Enemy").transform.gameObject.GetComponent<CapsuleCollider2D>(), false);
            }
        }

        #endregion
    }
}

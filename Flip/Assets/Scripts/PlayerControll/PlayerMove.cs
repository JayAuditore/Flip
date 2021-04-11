using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flip.PlayerControll
{
    public class PlayerMove : MonoBehaviour
    {
        #region 字段

        private float accelerationTimer;
        private float slowDownTimer;
        private float crouchTimer;
        private Vector2 Velocity;
        private Rigidbody2D rb;
        private PlayerInput playerInput;

        [Header("Float")]
        public float AccelerationTime;
        public float JumpForce;
        public float RushJumpForce;
        public float Speed;
        public float CrouchSpeed;
        public float ClimbSpeed;
        public float AugmentedVelocity;
        [Space]
        [Header("Bool")]
        public bool LeftFoot;
        public bool RightFoot;
        [Space]
        [Header("Component")]
        public CapsuleCollider2D Coll;
        public Transform Ground1;
        public Transform Ground2;
        public Transform Ceiling1;
        public Transform Ceiling2;
        [Space]
        public LayerMask Ground;

        #endregion

        #region Unity回调

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            playerInput = GetComponent<PlayerInput>();
        }

        void Update()
        {
            GroundCheck();
            Crouch();
            Jump();
        }

        void FixedUpdate()
        {
            GroundMove();
        }

        #endregion

        #region 方法

        //地面检测
        public void GroundCheck()
        {
            LeftFoot = Physics2D.OverlapCircle(Ground1.position, 0.1f, Ground);
            RightFoot = Physics2D.OverlapCircle(Ground2.position, 0.1f, Ground);

            if (!LeftFoot && !RightFoot)
            {
                playerInput.IsGrounded = false;
            }
            if (LeftFoot || RightFoot)
            {
                playerInput.IsGrounded = true;
            }
        }

        //计算速度
        public Vector2 CalculateVelocity()
        {
            float horizontalMove = Input.GetAxisRaw("Horizontal");

            //有左右输入
            if (horizontalMove != 0)
            {
                slowDownTimer = 0;

                //地面上
                if (playerInput.IsGrounded)
                {
                    //冲刺
                    if (playerInput.IsAccelerating)
                    {
                        accelerationTimer += Time.fixedDeltaTime * (1 / AccelerationTime);
                        Velocity = new Vector2(Mathf.Lerp(rb.velocity.x, AugmentedVelocity * horizontalMove, accelerationTimer), rb.velocity.y);
                    }
                    //蹲下
                    else if (playerInput.CrouchPressed)
                    {
                        crouchTimer += Time.fixedDeltaTime * (1 / 0.2f);
                        Velocity = new Vector2(Mathf.Lerp(rb.velocity.x, horizontalMove * CrouchSpeed, crouchTimer), rb.velocity.y);
                    }
                    //正常走
                    else
                    {
                        Velocity = new Vector2(horizontalMove * Speed, rb.velocity.y);
                    }

                    //重置timer
                    if (!playerInput.IsAccelerating)
                    {
                        accelerationTimer = 0;
                    }
                    if (!playerInput.CrouchPressed)
                    {
                        crouchTimer = 0;
                    }
                }
                //空中
                else if (!playerInput.IsGrounded)
                {
                    //初速度为0
                    if (rb.velocity.x * horizontalMove == 0)
                    {
                        Velocity = new Vector2(horizontalMove * Speed, rb.velocity.y);
                    }
                    //同向移动
                    if (rb.velocity.x * horizontalMove > 0)
                    {
                        Velocity = new Vector2(rb.velocity.x, rb.velocity.y);
                    }
                    //反向移动
                    if (rb.velocity.x * horizontalMove < 0)
                    {
                        Velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
                    }
                }
            }
            //无左右输入
            else if (horizontalMove == 0)
            {
                slowDownTimer += Time.fixedDeltaTime * (1 / 0.2f);
                Velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, slowDownTimer), rb.velocity.y);
            }

            return Velocity;
        }

        //速度赋值
        void GroundMove()
        {
            rb.velocity = CalculateVelocity();
        }

        //普通跳跃
        void SetNormalJump()
        {
            playerInput.IsJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            playerInput.JumpCount--;
            playerInput.JumpPressed = false;
        }

        //跑跳
        void SetRushJump()
        {
            playerInput.IsJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, RushJumpForce);
            playerInput.JumpCount--;
            playerInput.JumpPressed = false;
        }

        //跳跃判断
        void Jump()
        {
            if (playerInput.CanJump)
            {
                //初始化
                if (playerInput.IsGrounded && !playerInput.CrouchPressed)
                {
                    playerInput.JumpCount = 1;
                    playerInput.IsJumping = false;
                }

                //普通的跳跃
                if (playerInput.NormalJumping && playerInput.IsGrounded)
                {
                    SetNormalJump();
                }
                //跑跳
                else if (playerInput.RushJumping && rb.velocity.x != 0 && playerInput.IsGrounded)
                {
                    SetRushJump();
                }
                //按住shift原地起跳
                else if (playerInput.RushJumping && playerInput.IsGrounded)
                {
                    SetNormalJump();
                }
            }
        }

        //蹲下
        void Crouch()
        {
            //蹲下
            if (playerInput.CrouchPressed)
            {
                Coll.size = new Vector2(Coll.size.x, 0.5f);
                Coll.offset = new Vector2(Coll.offset.x, -0.25f);
                playerInput.CanJump = false;
            }
            //站立
            if (!playerInput.CrouchPressed)
            {
                Coll.size = new Vector2(Coll.size.x, 1f);
                Coll.offset = new Vector2(Coll.offset.x, 0f);
                playerInput.CanJump = true;
            }
        }

        #endregion
    }
}

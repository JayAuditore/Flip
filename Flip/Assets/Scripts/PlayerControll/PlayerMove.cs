using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flip.PlayerControll
{
    public class PlayerMove : MonoBehaviour
    {
        #region 字段

        private Rigidbody2D rb;
        private PlayerInput playerInput;

        public float AccelerationTime;
        public float JumpForce;
        public float Speed;
        public float CrouchSpeed;
        public float AugmentedVelocity;
        public Transform GroundCheck;
        public Transform CeilingCheck;
        public BoxCollider2D Coll;
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
            if (Input.GetKeyUp(KeyCode.S))
            {
                Coll.size = new Vector2(Coll.size.x, Coll.size.y * 2);
                Coll.offset = new Vector2(Coll.offset.x, Coll.offset.y + (Coll.size.y / 4));
            }
        }

        void FixedUpdate()
        {
            playerInput.IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.1f, Ground);
            playerInput.CanJump = Physics2D.OverlapCircle(CeilingCheck.position, 0.1f, Ground);
            Move();
        }

        #endregion

        #region 方法

        //移动
        void GroundMove()
        {
            float horizontalMove = Input.GetAxisRaw("Horizontal");

            if (horizontalMove != 0)
            {
                //地面上
                if (playerInput.IsGrounded)
                {
                    //冲刺
                    if (playerInput.IsAccelerating)
                    {
                        rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, AugmentedVelocity * horizontalMove, Time.deltaTime * (1 / 0.1f)), rb.velocity.y);
                    }
                    //蹲下
                    else if (playerInput.CrouchPressed)
                    {
                        rb.velocity = new Vector2(CrouchSpeed * horizontalMove, rb.velocity.y);
                    }
                    //正常走
                    else
                    {
                        rb.velocity = new Vector2(Speed * horizontalMove, rb.velocity.y);
                    }
                }
                //空中
                else if (!playerInput.IsGrounded)
                {
                    rb.velocity = new Vector2(Speed * horizontalMove, rb.velocity.y);
                }
            }
            else
            {
                rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, Time.deltaTime * (1 / 0.2f)), rb.velocity.y);

            }
        }

        //跳跃
        void Jump()
        {
            if (!playerInput.CanJump)
            {
                if (playerInput.IsGrounded && !playerInput.CrouchPressed)
                {
                    playerInput.JumpCount = 1;
                    playerInput.IsJumping = false;
                }

                if (playerInput.JumpPressed && playerInput.IsGrounded)
                {
                    playerInput.IsJumping = true;
                    rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                    playerInput.JumpCount--;
                    playerInput.JumpPressed = false;
                }
            }
        }

        //蹲下
        void Crouch()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Coll.size = new Vector2(Coll.size.x, Coll.size.y / 2);
                Coll.offset = new Vector2(Coll.offset.x, Coll.offset.y - (Coll.size.y / 2));
            }
        }

        void Move()
        {
            GroundMove();
            Jump();
            Crouch();
        }

        #endregion
    }
}

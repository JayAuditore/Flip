using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Flip.PlayerControll
{
    public class EntityMove : MonoBehaviour
    {
        #region 字段

        private float accelerationTimer;
        private float crouchTimer;
        private Vector2 Velocity;
        private Rigidbody2D rb;
        private EntityInput entityInput;

        [Header("Float")]
        public float AccelerationTime;
        public float JumpForce;
        public float RushJumpForce;
        public float Speed;
        public float CrouchSpeed;
        public float AugmentedVelocity;
        public float PushingSpeed;
        public float SlowDownTimer;

        [Header("StateData")]
        public MoveStateData standStateData;
        public MoveStateData crouchStateData;

        [Space]
        [Header("Bool")]
        public bool LeftFoot;
        public bool RightFoot;

        [Space]
        [Header("Component")]
        public CapsuleCollider2D Coll;
        public Transform LeftFootTrans;
        public Transform RightFootTrans;
        public Transform LeftHeadTrans;
        public Transform RightHeadTrans;

        [Space]
        public LayerMask Ground;

        #endregion

        #region Unity回调

        void Awake()
        {
            entityInput = GetComponent<EntityInput>();
        }

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
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
            LeftFoot = Physics2D.OverlapCircle(LeftFootTrans.position, 0.1f, Ground);
            RightFoot = Physics2D.OverlapCircle(RightFootTrans.position, 0.1f, Ground);

            if (!LeftFoot && !RightFoot)
            {
                entityInput.IsGrounded = false;
            }
            else if (LeftFoot || RightFoot)
            {
                entityInput.IsGrounded = true;
            }
        }

        //计算速度
        public Vector2 CalculateVelocity()
        {
            //有左右输入
            if (entityInput.horizontalMove != 0)
            {
                SlowDownTimer = 0;

                transform.localScale = new Vector3(entityInput.horizontalMove, transform.localScale.y, 1);

                //地面上
                if (entityInput.IsGrounded)
                {
                    //推箱子
                    if (entityInput.IsPushing)
                    {
                        Velocity = new Vector2(entityInput.horizontalMove * PushingSpeed, rb.velocity.y);
                    }
                    //冲刺
                    else if (entityInput.IsAccelerating)
                    {
                        accelerationTimer += Time.fixedDeltaTime * (1 / AccelerationTime);
                        Velocity = new Vector2(Mathf.Lerp(rb.velocity.x, AugmentedVelocity * entityInput.horizontalMove, accelerationTimer), rb.velocity.y);
                    }
                    //蹲下
                    else if (entityInput.CrouchPressed)
                    {
                        crouchTimer += Time.fixedDeltaTime * (1 / 0.2f);
                        Velocity = new Vector2(Mathf.Lerp(rb.velocity.x, entityInput.horizontalMove * CrouchSpeed, crouchTimer), rb.velocity.y);
                    }
                    //正常走
                    else
                    {
                        Velocity = new Vector2(entityInput.horizontalMove * Speed, rb.velocity.y);
                    }

                    //重置timer
                    if (!entityInput.IsAccelerating)
                    {
                        accelerationTimer = 0;
                    }
                    if (!entityInput.CrouchPressed)
                    {
                        crouchTimer = 0;
                    }
                }
                //空中
                else if (!entityInput.IsGrounded)
                {
                    //初速度为0
                    if (rb.velocity.x * entityInput.horizontalMove == 0)
                    {
                        Velocity = new Vector2(entityInput.horizontalMove * Speed, rb.velocity.y);
                    }
                    //同向移动
                    if (rb.velocity.x * entityInput.horizontalMove > 0)
                    {
                        Velocity = new Vector2(rb.velocity.x, rb.velocity.y);
                    }
                    //反向移动
                    if (rb.velocity.x * entityInput.horizontalMove < 0)
                    {
                        Velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
                    }
                }
            }
            //无左右输入
            else if (entityInput.horizontalMove == 0)
            {
                SlowDownTimer += Time.fixedDeltaTime * (1 / 0.2f);
                Velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, SlowDownTimer), rb.velocity.y);
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
            entityInput.IsJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            entityInput.JumpCount--;
            entityInput.JumpPressed = false;
        }

        //跑跳
        void SetRushJump()
        {
            entityInput.IsJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, RushJumpForce);
            entityInput.JumpCount--;
            entityInput.JumpPressed = false;
        }

        //跳跃判断
        void Jump()
        {
            if (entityInput.CanJump)
            {
                //初始化
                if (entityInput.IsGrounded && !entityInput.CrouchPressed)
                {
                    entityInput.JumpCount = 1;
                    entityInput.IsJumping = false;
                }

                //普通的跳跃
                if (entityInput.NormalJumping && entityInput.IsGrounded)
                {
                    SetNormalJump();
                }
                //跑跳
                else if (entityInput.RushJumping && rb.velocity.x != 0 && entityInput.IsGrounded)
                {
                    SetRushJump();
                }
                //按住shift原地起跳
                else if (entityInput.RushJumping && entityInput.IsGrounded)
                {
                    SetNormalJump();
                }
            }
        }

        //蹲下
        void Crouch()
        {
            //蹲下
            if (entityInput.CrouchPressed)
            {
                SetStateData(crouchStateData);
                entityInput.CanJump = false;
            }
            //站立
            else
            {
                SetStateData(standStateData);
                entityInput.CanJump = true;
            }
        }

        private void SetStateData(MoveStateData stateData)
        {
            // 临时代码
            if (stateData.OffSet == Vector2.zero) return;
            LeftFootTrans.localPosition = stateData.LeftFootPos;
            RightFootTrans.localPosition = stateData.RightFootPos;
            LeftHeadTrans.localPosition = stateData.LeftHeadPos;
            RightHeadTrans.localPosition = stateData.RightHeadPos;
            Coll.direction = stateData.Direction;
            Coll.offset = stateData.OffSet;
            Coll.size = stateData.Size;
        }

        #endregion
    }
}

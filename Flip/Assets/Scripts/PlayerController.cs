using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region 字段

    [SerializeField] private bool jumpPressed;
    [SerializeField] private bool crouchPressed;
    [SerializeField] private float accelerationTime;
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    [SerializeField] private float augmentedVelocity;
    private int jumpCount;
    private Rigidbody2D rb;

    public bool IsGrounded;
    public bool IsJumping;
    public bool IsAccelerating;
    public Transform GroundCheck;
    public Transform CeilingCheck;
    public BoxCollider2D Coll;
    public LayerMask Ground;

    #endregion

    #region Unity回调

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && IsGrounded)
        {
            IsAccelerating = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            IsAccelerating = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouchPressed = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            crouchPressed = false;
            Coll.size = new Vector2(Coll.size.x, Coll.size.y * 2);
            Coll.offset = new Vector2(Coll.offset.x, Coll.offset.y + (Coll.size.y / 4));
        }
    }

    void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.1f, Ground);
        GroundMove();
        Jump();
        Crouch();
    }

    #endregion

    #region 方法

    //移动
    void GroundMove()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");

        if (horizontalMove != 0 && IsAccelerating)
        {
            rb.velocity = new Vector2(Mathf.Lerp(horizontalMove * speed, horizontalMove * augmentedVelocity, Time.deltaTime * (1 / accelerationTime)), rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
        }

        if (horizontalMove != 0)
        {
            transform.localScale = new Vector3(horizontalMove, 1, 1);
        }
    }

    //跳跃
    void Jump()
    {
        if (IsGrounded)
        {
            jumpCount = 1;
            IsJumping = false;
        }
        if (jumpPressed && IsGrounded)
        {
            IsJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
        }
    }

    //蹲下
    void Crouch()
    {
        if (crouchPressed && IsGrounded)
        {
            Coll.size = new Vector2(Coll.size.x, Coll.size.y / 2);
            Coll.offset = new Vector2(Coll.offset.x, Coll.offset.y - (Coll.size.y / 2));
            crouchPressed = false;
        }
    }

    #endregion
}

using System.Collections;
using System.Collections.Generic;
using Flip.PlayerControll;
using UnityEngine;

public class RunTest : MonoBehaviour
{
    public Animator animator;

    public EntityInput entityInput;

    public Rigidbody2D rig;

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("XSpeed", entityInput.horizontalMove == 0 ? 0 : 1);
        animator.SetFloat("YSpeed", rig.velocity.y);
        animator.SetBool("IsLand", entityInput.IsGrounded);
        animator.SetBool("IsCrouch", entityInput.CrouchPressed);
    }
}

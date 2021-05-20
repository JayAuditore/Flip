using System.Collections;
using System.Collections.Generic;
using Flip.PlayerControll;
using UnityEngine;

public class RunTest : MonoBehaviour
{
    public Animator animator;

    public EntityInput entityInput;
    public EntityMove entityMove;
    public Rigidbody2D rig;

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("XSpeed", Mathf.Abs(entityInput.horizontalMove));
        animator.SetFloat("YSpeed", rig.velocity.y);
        animator.SetFloat("MoveMultipy", entityInput.IsAccelerating ? entityMove.AugmentedVelocity / entityMove.Speed : 1);
        animator.SetBool("IsLand", entityInput.IsGrounded);
        animator.SetBool("IsCrouch", entityInput.CrouchPressed);
    }
}

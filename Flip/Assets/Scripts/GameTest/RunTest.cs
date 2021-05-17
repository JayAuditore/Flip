using System.Collections;
using System.Collections.Generic;
using Flip.PlayerControll;
using UnityEngine;

public class RunTest : MonoBehaviour
{
    public Animator animator;

    public EntityInput entityInput;

    public Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            animator.SetInteger("XSpeed", 3);
            animator.SetFloat("CrawlSpeed", 1);
        }
        else
        {
            animator.SetInteger("XSpeed", 0);
            animator.SetFloat("CrawlSpeed", 0);
        }
        animator.SetBool("land", entityInput.IsGrounded);
        animator.SetFloat("YSpeed", rig.velocity.y);
    }
}

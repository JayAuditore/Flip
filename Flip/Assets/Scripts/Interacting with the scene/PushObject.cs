﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    // TODO: 增加一个地面检测
    public string layerMask;
    protected Interact interact=new Interact() ;
    public RaycastHit2D[] raycastHit2D;
    public void Start()
    {
    }
    public void FixedUpdate()
    {
        Push(this.gameObject, 1.5f, layerMask );
    }
    public void canpush()
    {
        if (Input.GetKey(KeyCode.F) && ((raycastHit2D[0].transform.position.x - transform.position.x) * transform.localScale.x > 0))
        {
            raycastHit2D[0].transform.position = raycastHit2D[0].transform.position + new Vector3(Input.GetAxisRaw("Horizontal")*Time.fixedDeltaTime, 0, 0);
        }
        else
        {
        }
       
    }
    public void Push(GameObject target, float rads, string collidermask)
    {
        raycastHit2D = Physics2D.RaycastAll(target.transform.position+new Vector3(0,2,0), new Vector3(1,0,0)*transform.localScale.x,rads,LayerMask.GetMask(collidermask));
        if (raycastHit2D.Length>0)
        {
            canpush();
        }
        else
        {
        }
    }
}

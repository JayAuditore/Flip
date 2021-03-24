using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public delegate void funtion();

    public Collider2D[] cols;
    public void Interacting(GameObject target, float rads, string collidermask)
    {
        cols = Physics2D.OverlapCircleAll(target.transform.position, rads, LayerMask.GetMask(collidermask));
        if (cols.Length > 0)
        {
        }
        else
        {
        }
    }
    public void Interacting(GameObject target, float rads, string collidermask, funtion fun1)
    {
        cols = Physics2D.OverlapCircleAll(target.transform.position, rads, LayerMask.GetMask(collidermask));
        if (cols.Length > 0)
        {
            fun1();
        }
        else
        {
        }
    }
    public void Interacting(GameObject target, float rads, string collidermask, funtion fun1, funtion fun2)
    {
        cols = Physics2D.OverlapCircleAll(target.transform.position, rads, LayerMask.GetMask(collidermask));
        if (cols.Length > 0)
        {
            fun1();
        }
        else
        {
            fun2();
        }
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public delegate void funtion(); 
    private Interact instance;
    private void Awake()
    {
        if (instance == null)
        {
            Instantiate(instance);
        }
    }
    public static void Interacting(GameObject target,float rads,string collidermask)
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(target.transform.position, rads, LayerMask.GetMask(collidermask));
        if (cols.Length > 0)
        {
            Debug.Log("已经感应到物体了");
        }
        else
        {

        }
    }
    public static void Interacting(GameObject target, float rads, string collidermask,funtion fun1,funtion fun2)
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(target.transform.position, rads, LayerMask.GetMask(collidermask));
        if (cols.Length > 0)
        {
            Debug.Log("已经感应到物体了");
            fun1();
        }
        else
        {
            fun2();
        }
    }

}

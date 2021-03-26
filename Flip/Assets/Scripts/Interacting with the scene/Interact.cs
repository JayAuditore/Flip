using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public delegate void funtion();

    public Collider2D[] _collider2D;
    public void Interacting(GameObject target, float radius, string colliderMask)
    {
        _collider2D = Physics2D.OverlapCircleAll(target.transform.position, radius, LayerMask.GetMask(colliderMask));
        if (_collider2D.Length > 0)
        {
        }
        else
        {
        }
    }
    public void Interacting(GameObject target, float radius, string colliderMask, funtion funtion1)
    {
        _collider2D = Physics2D.OverlapCircleAll(target.transform.position, radius, LayerMask.GetMask(colliderMask));
        if (_collider2D.Length > 0)
        {
            funtion1();
        }
        else
        {
        }
    }
    public void Interacting(GameObject target, float radius, string colliderMask, funtion funtion1, funtion funtion2)
    {
        _collider2D = Physics2D.OverlapCircleAll(target.transform.position, radius, LayerMask.GetMask(colliderMask));
        if (_collider2D.Length > 0)
        {
            funtion1();
        }
        else
        {
            funtion2();
        }
    }



}

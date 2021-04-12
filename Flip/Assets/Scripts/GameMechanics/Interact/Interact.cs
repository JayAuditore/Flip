using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Flip.Interact
{
    public class Interact
    {
        #region 单例
        private Interact() { }
        public static class InteractInstance
        {
            public static Interact instance = new Interact();
        }
        public static Interact GetInstance()
        {
            return InteractInstance.instance;
        }
        #endregion
        #region 字段
        public delegate void funtion();         //委托的方法
        public static Collider2D[] _collider2D;    //检测到的物体
        #endregion

        //target表示检测到的物品，rads代表检测的范围，collidermask表示要检测的图层,funtion1指的是检测到后就调用的方法，funtion2指的是没有检测就调用的方法
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
}


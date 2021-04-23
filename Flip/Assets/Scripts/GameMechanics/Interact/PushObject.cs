using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flip.PlayerControll;

namespace Flip.Interact
{
    public class PushObject : MonoBehaviour
    {
        #region 字段

        // TODO: 增加一个地面检测
        public bool IsPushing;
        public LayerMask LayerMask;
        public RaycastHit2D[] RaycastHit2D;

        private Rigidbody2D rigidbody2DOfObject;

        #endregion

        #region Unity回调

        public void Update()
        {
            Push(this.gameObject, 0.51f, LayerMask);
        }

        #endregion

        #region 方法

        //检测到之后要做的事情
        public void Canpush()
        {
            //检测键盘输入
            if (Input.GetKey(KeyCode.F) && (RaycastHit2D[0].transform.position.x - transform.position.x) * transform.localScale.x > 0)
            {
                IsPushing = true;
                rigidbody2DOfObject.mass = 0.1f;
            }
            else
            {
                rigidbody2DOfObject.mass = 10000;
                rigidbody2DOfObject.velocity = new Vector2(0, 0);
                rigidbody2DOfObject = null;
                IsPushing = false;
            }
        }

        //target表示检测到的物品，rads代表检测的范围，collidermask表示要检测的图层
        public void Push(GameObject target, float rads, LayerMask collidermask)
        {
            RaycastHit2D = Physics2D.RaycastAll(target.transform.position, new Vector2(1, 0) * transform.localScale.x, rads, LayerMask);
            if (RaycastHit2D.Length > 0&&RaycastHit2D[0].transform.CompareTag("Box"))
            {
                rigidbody2DOfObject = RaycastHit2D[0].transform.GetComponent<Rigidbody2D>();
                Canpush();
            }
            else
            {
                IsPushing = false;
                if (rigidbody2DOfObject)
                {
                    rigidbody2DOfObject.mass = 10000;
                    rigidbody2DOfObject.velocity = new Vector2(0, 0);
                    rigidbody2DOfObject = null;
                }
            }
        }
        #endregion
    }
}


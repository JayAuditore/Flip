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
        public float Velocity;
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
            if (Input.GetKey(KeyCode.F))
            {
                IsPushing = true;
                //下面的我看不懂
                if ((RaycastHit2D[0].transform.position.x - transform.position.x) * transform.localScale.x > 0)
                {
                    rigidbody2DOfObject.mass = 0.1f;
                    //RaycastHit2D[0].transform.position = RaycastHit2D[0].transform.position + new Vector3(Velocity * Time.fixedDeltaTime * transform.localScale.x, 0, 0);
                }
                else
                {
                }
            }
        }

        //target表示检测到的物品，rads代表检测的范围，collidermask表示要检测的图层
        public void Push(GameObject target, float rads, LayerMask collidermask)
        {
            RaycastHit2D = Physics2D.RaycastAll(target.transform.position, new Vector2(1, 0) * transform.localScale.x, rads, LayerMask);

            if (RaycastHit2D.Length > 0)
            {
                rigidbody2DOfObject = RaycastHit2D[0].transform.GetComponent<Rigidbody2D>();
                Canpush();
            }
            else
            {
                rigidbody2DOfObject.mass = 100;
                rigidbody2DOfObject.velocity = new Vector2(0, 0);
                rigidbody2DOfObject = null;
            }
        }

        #endregion
    }
}


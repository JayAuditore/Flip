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
        public float Velocity;
        public LayerMask LayerMask;
        public RaycastHit2D[] RaycastHit2D;

        private EntityInput entityInput;

        #endregion

        #region Unity回调

        private void Awake()
        {
            entityInput = GetComponent<EntityInput>();   
        }
        
        public void FixedUpdate()
        {
            Push(this.gameObject, 1.5f, LayerMask);
        }

        #endregion

        #region 方法

        //检测到之后要做的事情
        public void Canpush()
        {
            if (entityInput.IsPushing && ((RaycastHit2D[0].transform.position.x - transform.position.x) * transform.localScale.x > 0))
            {
                RaycastHit2D[0].transform.position = RaycastHit2D[0].transform.position + new Vector3(Velocity * Time.fixedDeltaTime * transform.localScale.x, 0, 0);
            }
            else
            {

            }
        }

        //target表示检测到的物品，rads代表检测的范围，collidermask表示要检测的图层
        public void Push(GameObject target, float rads, LayerMask collidermask)
        {
            RaycastHit2D = Physics2D.RaycastAll(target.transform.position , new Vector3(1, 0, 0) * transform.localScale.x, rads, LayerMask);

            if (RaycastHit2D.Length > 0)
            {
                Canpush();
            }
        }

        #endregion
    }
}



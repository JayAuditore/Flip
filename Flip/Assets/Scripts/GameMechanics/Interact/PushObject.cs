using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flip.Interact
{
    public class PushObject : MonoBehaviour
    {
        #region 字段
        // TODO: 增加一个地面检测
        public string layerMask;
        public RaycastHit2D[] raycastHit2D;
        #endregion
    

        public void Update()
        {
            Push(this.gameObject, 1.5f, layerMask);
        }
        public void Canpush()//检测到之后要做的事情
        {
            if (Input.GetKey(KeyCode.F) && ((raycastHit2D[0].transform.position.x - transform.position.x) * transform.localScale.x > 0))
            {
                raycastHit2D[0].transform.position = raycastHit2D[0].transform.position + new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime, 0, 0);
            }
            else
            {
            }

        }
        //target表示检测到的物品，rads代表检测的范围，collidermask表示要检测的图层
        public void Push(GameObject target, float rads, string collidermask)
        {
            raycastHit2D = Physics2D.RaycastAll(target.transform.position + new Vector3(0, 2, 0), new Vector3(1, 0, 0) * transform.localScale.x, rads, LayerMask.GetMask(collidermask));
            if (raycastHit2D.Length > 0)
            {
                Canpush();
            }
        }
    }
}



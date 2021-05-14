using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Flip.PlayerControll;

namespace Flip.AI
{
    public class EnemyInput : MonoBehaviour
    {
        #region 字段

        private GameObject[] Player;
        private float left;
        private float right;
        private Transform leftPoint;
        private Transform rightPoint;
        private EntityInput entityInput;

        public float lookDistance;          // 观察距离
        public float lookAngle;             // 观察角度
        public float lookOffSet;            // 观察差值
        public float heightOffSet;          // 高度差值
        public LayerMask lookLayer;
        public LayerMask occlusionLayer;

        #endregion

        #region Unity回调

        void Awake()
        {
            entityInput = GetComponent<EntityInput>();
        }

        void Start()
        {
            FindPlayer();
            FindPoint();
        }

        #endregion

        #region 方法

        public bool SwitchCondition()
        {
            // 正反面视野反转值
            int lookAtMultiply = transform.localScale.x > 0 ? -1 : 1;
            Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, lookDistance, lookLayer);
            Vector3 startVec = transform.position + new Vector3(0, heightOffSet, 0);
            Vector3 endVec = transform.position + new Vector3(lookDistance - lookOffSet, heightOffSet, 0);
            RaycastHit2D sceneObj = Physics2D.Raycast(startVec, transform.right * lookAtMultiply, (endVec - startVec).magnitude, occlusionLayer);
            // 视线被遮挡或检测不到玩家
            if (sceneObj.collider != null || playerCollider == null)
            {
                return true;
            }
            // 判断是否再检测距离内
            Vector3 offSetVec = (transform.position - new Vector3(lookOffSet, 0, 0) * lookAtMultiply);
            if ((playerCollider.transform.position.x - transform.position.x) * lookAtMultiply > 0 && Mathf.Abs(Vector2.SignedAngle((transform.position - offSetVec), playerCollider.transform.position - offSetVec)) < lookAngle)
            {
                // 切换到追踪状态
                return false;
            }
            else
            {
                // 切换到巡逻状态
                return true;
            }
        }

        //绘制视野范围
        private void OnDrawGizmosSelected()
        {
            Handles.color = new Color(1, 1, 1, 0.3f);
            Handles.DrawSolidArc(transform.position - new Vector3(lookOffSet, 0, 0), transform.forward, transform.right, lookAngle, lookDistance);
            Handles.DrawSolidArc(transform.position - new Vector3(lookOffSet, 0, 0), transform.forward, transform.right, -lookAngle, lookDistance);
            Handles.color = new Color(0, 1, 1, 1.0f);
            Handles.DrawLine(transform.position + new Vector3(0, heightOffSet, 0), transform.position + new Vector3(lookDistance - lookOffSet, heightOffSet, 0));
        }

        //追玩家
        public void EnemyTrack()
        {
            if (transform.localPosition.x - Player[0].transform.localPosition.x < 0)
            {
                entityInput.horizontalMove = 1;
                entityInput.IsAccelerating = true;
            }
            else if (transform.localPosition.x - Player[0].transform.localPosition.x > 0)
            {
                entityInput.horizontalMove = -1;
                entityInput.IsAccelerating = true;
            }
        }

        //找到玩家这个物体
        public void FindPlayer()
        {
            Player = GameObject.FindGameObjectsWithTag("Player");
        }

        //获取巡逻的起始点
        public void FindPoint()
        {
            leftPoint = transform.GetChild(0);
            rightPoint = transform.GetChild(1);
            left = leftPoint.localPosition.x;
            right = rightPoint.transform.localPosition.x;
            Destroy(leftPoint.gameObject);
            Destroy(rightPoint.gameObject);
        }

        //回到巡逻范围
        public void EnemyPatrol()
        {
            entityInput.IsAccelerating = false;
            if (transform.localPosition.x < left)
            {
                entityInput.horizontalMove = 1;
            }

            if (transform.localPosition.x > left && transform.localPosition.x < right)
            {
                if (entityInput.horizontalMove == 0)
                {
                    entityInput.horizontalMove = 1;
                }
                else
                {
                    return;
                }
            }

            if (transform.localPosition.x > right)
            {
                entityInput.horizontalMove = -1;
            }
        }

        #endregion
    }
}

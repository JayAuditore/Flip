using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;
public class BaseEnermy : MonoBehaviour
{
    public float lookDistance;          // 观察距离
    public float lookAngle;             // 观察角度
    public float lookOffSet;            // 观察差值
    public float heightOffSet;          // 高度差值
    public LayerMask lookLayer;
    public LayerMask occlusionLayer;
    private void Update()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, lookDistance, lookLayer);
        Vector3 startVec = transform.position + new Vector3(0, heightOffSet, 0);
        Vector3 endVec = transform.position + new Vector3(lookDistance - lookOffSet, heightOffSet, 0);
        RaycastHit2D sceneObj = Physics2D.Raycast(startVec, transform.right, (endVec - startVec).magnitude, occlusionLayer);
        // 视线被遮挡或检测不到玩家
        if (sceneObj.collider != null || playerCollider == null)
        {
            // 切换到巡逻状态

            return;
        }
        // 判断是否再检测距离内
        Vector3 offSetVec = (transform.position - new Vector3(lookOffSet, 0, 0));
        if (playerCollider.transform.position.x - transform.position.x > 0 && Mathf.Abs(Vector2.SignedAngle(transform.position - offSetVec, playerCollider.transform.position - offSetVec)) < lookAngle)
        {
            // 切换到追踪状态

        }
        else
        {
            // 切换到巡逻状态
        }
    }
    private void OnDrawGizmosSelected()
    {
        Handles.color = new Color(1, 1, 1, 0.3f);
        Handles.DrawSolidArc(transform.position - new Vector3(lookOffSet, 0, 0), transform.forward, transform.right, lookAngle, lookDistance);
        Handles.DrawSolidArc(transform.position - new Vector3(lookOffSet, 0, 0), transform.forward, transform.right, -lookAngle, lookDistance);
        Handles.color = new Color(0, 1, 1, 1.0f);
        Handles.DrawLine(transform.position + new Vector3(0, heightOffSet, 0), transform.position + new Vector3(lookDistance - lookOffSet, heightOffSet, 0));
    }
}

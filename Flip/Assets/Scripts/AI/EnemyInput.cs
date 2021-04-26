using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flip.PlayerControll;

public class EnemyInput : MonoBehaviour
{
    #region 字段

    private GameObject[] Player;
    [SerializeField] private float left;
    [SerializeField] private float right;
    private Transform leftPoint;
    private Transform rightPoint;
    private EntityInput entityInput;

    #endregion

    #region Unity回调

    void Awake()
    {
        entityInput = GetComponent<EntityInput>();
    }

    private void Start()
    {
        FindPlayer();
        FindPoint();
    }

    #endregion

    #region 方法

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

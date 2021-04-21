using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flip.Module;
public class GlobalWorldReverseManager : BaseSingletonWithMono<GlobalWorldReverseManager>
{
    public Vector3 WorldOffSet => worldOffSet;          // 外部获取
    [SerializeField] private Transform frontWorld;      // 正面世界坐标
    [SerializeField] private Transform backWorld;       // 反面世界坐标
    [SerializeField] private bool isBack;               // 记录当前处于正面或反面
    private Camera gameCamera;                          // 主场景摄像机
    private GameObject player;                          // 玩家
    private Vector3 worldOffSet;                        // 正反世界偏移

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        worldOffSet = frontWorld.transform.position - backWorld.transform.position;
    }

    /// <summary>
    /// 切换到正面世界
    /// </summary>
    public void SwitchToFront()
    {
        // 在背面 则位置转换到正面
        if (isBack)
        {
            // TODO: 更换变换方法
            // 变换摄像机的坐标 变换玩家的坐标
            gameCamera.transform.position += GlobalWorldReverseManager.Instance.WorldOffSet;
            player.transform.position += GlobalWorldReverseManager.Instance.WorldOffSet;
        }
        isBack = false;
    }

    /// <summary>
    /// 切换到背面世界
    /// </summary>
    public void SwitchToBack()
    {
        // 不在背面 则位置转换到背面
        if (!isBack)
        {
            // 变换摄像机的坐标 变换玩家的坐标
            gameCamera.transform.position -= GlobalWorldReverseManager.Instance.WorldOffSet;
            player.transform.position -= GlobalWorldReverseManager.Instance.WorldOffSet;
        }
        isBack = true;
    }
    private void Update()
    {
        // TODO: 修改为玩家使用切换正反面技能时调用
        if (Input.GetKeyDown(KeyCode.M))
        {
            SwitchToFront();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            SwitchToBack();
        }
    }
}

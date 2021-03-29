using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Camera gameCamera;     // 主场景摄像机
    [SerializeField] private GameObject player;     // 玩家

    [SerializeField] private bool isBack = false;   // 记录当前处于正面或反面
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            // 在背面 则位置转换到正面
            if (isBack)
            {
                gameCamera.transform.position += GlobalWorldOffSet.Instance.WorldOffSet;
                player.transform.position += GlobalWorldOffSet.Instance.WorldOffSet;
            }
            isBack = false;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            // 不在背面 则位置转换到背面
            if (!isBack)
            {
                gameCamera.transform.position -= GlobalWorldOffSet.Instance.WorldOffSet;
                player.transform.position -= GlobalWorldOffSet.Instance.WorldOffSet;
            }
            isBack = true;
        }
    }
}

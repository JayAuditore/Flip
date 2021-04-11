using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flip.GameMechanics;
public class DropTrigger : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // 掉落
            ReversibleCubeManager.Instance.Fall("Cube1");
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            // 重新归位
            ReversibleCubeManager.Instance.Return("Cube1");
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            // 掉落
            ReversibleCubeManager.Instance.Fall("Cube2");
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            // 重新归位
            ReversibleCubeManager.Instance.Return("Cube2");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            // 掉落
            ReversibleCubeManager.Instance.Fall("Plane");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            // 重新归位
            ReversibleCubeManager.Instance.Return("Plane");
        }
    }
}

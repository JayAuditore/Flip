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
            ReversibleCubeManager.Instance.Fall("Cube");
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            // 重新归位
            ReversibleCubeManager.Instance.Return("Cube");
        }
    }
}

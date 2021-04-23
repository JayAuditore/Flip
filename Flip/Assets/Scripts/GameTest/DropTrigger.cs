using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flip.GameMechanics;
public class DropTrigger : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            // 重新归位
            MechanismCubeManager.Instance.Return("Cube1");
        }
    }
}

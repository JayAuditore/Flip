using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;
namespace Flip.GameMechanics
{
    [RequireComponent(typeof(BaseMechanismObject))]
    public class InteractTrigger : MonoBehaviour
    {
        [SerializeField] private bool isAbleToIntertact = true;         // 是否能够互动
        [SerializeField] private LayerMask intertactLayer;              // 允许互动的层级
        [SerializeField] private Vector2 intertactSize;                 // 互动检测半径
        [SerializeField] private IntertactStringEvent intertactEvent;   // 互动事件

        private string interactObjectUniqueID;
        private void Start()
        {
            interactObjectUniqueID = GetComponent<BaseMechanismObject>().UniqueID;
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(transform.position, intertactSize);
        }
        private void Update()
        {
            // 判断是否允许互动
            if (isAbleToIntertact)
            {
                Collider2D intertactCollider = Physics2D.OverlapBox(transform.position, intertactSize, 0, intertactLayer);
                if (intertactCollider == null) return;
                // 调用事件
                intertactEvent?.Invoke(interactObjectUniqueID);
            }
        }
        public void SetIntertactFalse()
        {
            isAbleToIntertact = false;
        }
        public void SetIntertactTrue()
        {
            isAbleToIntertact = true;
        }
    }

}

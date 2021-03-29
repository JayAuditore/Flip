using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Flip.GameMechanics
{
    public class ReversibleCube : BaseReversibleObject
    {
        public string UniqueID => uniqueID;             // 外部获取
        [SerializeField] private string uniqueID;       // 辨识同源正反面物体的ID
        [SerializeField] private Vector3 startVec;  // 起始位置
        [SerializeField] private Vector3 endVec;    // 结束位置
        private void Start()
        {
            ReversibleCubeManager.Instance.AddPair(this);
        }
        public void Fall()
        {
            gameObject.transform.localPosition = endVec;
        }
        public void Return()
        {
            gameObject.transform.localPosition = startVec;
        }
        public override void Reverse()
        {
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flip.GameMechanics
{
    public abstract class BaseMechanismObject : MonoBehaviour
    {
        public string UniqueID => uniqueID;                     // 外部获取
        public DirectionType Direction => directionType;        // 外部获取
        [SerializeField] protected string uniqueID;             // 辨识同源正反面物体的ID
        [SerializeField] protected DirectionType directionType; // 正面or反面
        [SerializeField] protected Vector3 startVec;            // 起始位置
        [SerializeField] protected Vector3 endVec;              // 结束位置
        protected virtual void Start()
        {
            MechanismCubeManager.Instance.AddPair(this);
        }

        public abstract void Transformation();
        public abstract void Reduction();

        [ContextMenu("ToStartTransform")]
        private void ToStartTransform()
        {
            transform.localPosition = startVec;
        }

        [ContextMenu("SetStartTransform")]
        private void SetStartTransform()
        {
            startVec = transform.localPosition;
        }

        [ContextMenu("SetEndTransform")]
        private void SetEndTransform()
        {
            endVec = transform.localPosition;
        }
    }
}


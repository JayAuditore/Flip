using System.Collections.Generic;
using System.Collections;
using UnityEngine;
namespace Flip.GameMechanics
{
    public class ReversePair
    {
        public BaseReversibleObject frontObj;
        public BaseReversibleObject backObj;
        public ReversePair(BaseReversibleObject cube)
        {
            // 构造函数
            AddObj(cube);
        }
        public void AddObj(BaseReversibleObject cube)
        {
            if (cube.gameObject.tag == "Front")
            {
                frontObj = cube;
            }
            else if (cube.gameObject.tag == "Back")
            {
                backObj = cube;
            }
        }
        public IEnumerable<BaseReversibleObject> Traversal()
        {
            yield return frontObj;
            yield return backObj;
        }
    }
}
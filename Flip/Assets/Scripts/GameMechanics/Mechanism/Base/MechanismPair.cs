using System.Collections.Generic;
using System.Collections;
using UnityEngine;
namespace Flip.GameMechanics
{
    public class MechanismPair
    {
        public BaseMechanismObject frontObj;
        public BaseMechanismObject backObj;
        public MechanismPair(BaseMechanismObject cube)
        {
            // 构造函数
            AddObj(cube);
        }
        public void AddObj(BaseMechanismObject cube)
        {
            // 判断物体正反面
            if (cube.Direction == DirectionType.Front)
            {
                frontObj = cube;
            }
            else if (cube.Direction == DirectionType.Back)
            {
                backObj = cube;
            }
        }
        public IEnumerable<BaseMechanismObject> Traversal()
        {
            // 遍历一次返回正面与反面物体
            yield return frontObj;
            yield return backObj;
        }
    }
}
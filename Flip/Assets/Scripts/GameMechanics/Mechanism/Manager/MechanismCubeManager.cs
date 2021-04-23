using System;
using System.Collections.Generic;
using UnityEngine;
using Flip.Module;
namespace Flip.GameMechanics
{

    public class MechanismCubeManager : BaseSingletonWithMono<MechanismCubeManager>
    {
        [SerializeField] private Dictionary<string, MechanismPair> pairDic = new Dictionary<string, MechanismPair>();

        private void Start()
        {
        }
        public void AddPair(BaseMechanismObject _cube)
        {
            if (pairDic.ContainsKey(_cube.UniqueID))
            {
                pairDic[_cube.UniqueID].AddObj(_cube);
            }
            else
            {
                pairDic.Add(_cube.UniqueID, new MechanismPair(_cube));
            }
        }
        public void Fall(string key)
        {
            // 遍历缓存中指定的某对物体 执行方块的下坠
            if (pairDic.ContainsKey(key))
            {
                foreach (BaseMechanismObject baseReversible in pairDic[key].Traversal())
                {
                    // 完成下坠
                    MechanismCube cube = baseReversible as MechanismCube;
                    cube.Transformation();
                }
            }
        }
        public void Return(string key)
        {
            // 遍历缓存中指定的某对物体 执行方块的归位
            if (pairDic.ContainsKey(key))
            {
                foreach (BaseMechanismObject baseReversible in pairDic[key].Traversal())
                {
                    // 完成下坠
                    MechanismCube cube = baseReversible as MechanismCube;
                    cube.Reduction();
                }
            }
        }
    }
}
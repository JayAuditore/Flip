using System;
using System.Collections.Generic;
using UnityEngine;
using Flip.Module;
namespace Flip.GameMechanics
{

    public class ReversibleCubeManager : BaseSingletonWithMono<ReversibleCubeManager>
    {
        [SerializeField] private Dictionary<string, ReversePair> pairDic = new Dictionary<string, ReversePair>();
        public void AddPair(ReversibleCube _cube)
        {
            if (pairDic.ContainsKey(_cube.UniqueID))
            {
                pairDic[_cube.UniqueID].AddObj(_cube);
            }
            else
            {
                pairDic.Add(_cube.UniqueID, new ReversePair(_cube));
            }
        }
        public void Fall(string key)
        {
            // 遍历缓存中指定的某对物体 执行此方法
            if (pairDic.ContainsKey(key))
            {
                foreach (BaseReversibleObject baseReversible in pairDic[key].Traversal())
                {
                    // 完成下坠
                    ReversibleCube cube = baseReversible as ReversibleCube;
                    cube.Fall();
                }
            }
        }
        public void Return(string key)
        {
            if (pairDic.ContainsKey(key))
            {
                foreach (BaseReversibleObject baseReversible in pairDic[key].Traversal())
                {
                    // 完成下坠
                    ReversibleCube cube = baseReversible as ReversibleCube;
                    cube.Return();
                }
            }
        }
    }
}
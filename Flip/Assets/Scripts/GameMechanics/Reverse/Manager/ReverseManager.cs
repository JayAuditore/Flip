// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Flip.Module;
// namespace Flip.GameMechanics
// {
//     public class ReverseManager : BaseSingletonWithMono<ReverseManager>
//     {
//         private Dictionary<string, ReversePair> reversePairDic = new Dictionary<string, ReversePair>();
        
//         public void AddReversePair(ReversibleCube cube)
//         {
//             if (reversePairDic.ContainsKey(cube.UniqueID))
//             {
//                 // 存在ID 证明以添加过一次物体
//                 reversePairDic[cube.UniqueID].AddObj(cube);
//             }
//             else
//             {
//                 reversePairDic.Add(cube.UniqueID, new ReversePair(cube));
//             }
//         }
//         public void TriggerReverse(string uniqueID)
//         {
//             if (reversePairDic.ContainsKey(uniqueID))
//             {
//                 reversePairDic[uniqueID].Trigger();
//             }
//         }
//     }

// }

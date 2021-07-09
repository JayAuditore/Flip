using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flip.Module;
using Flip.SaveSystem.Interface;

namespace Flip.Module
{
    public class UIResourcesManager : BaseSingletonWithMono<UIResourcesManager>
    {
        #region 字段

        #endregion

        #region 方法

        /// <summary>
        /// 自动加载UI至给定的父节点下 并调用Init初始化
        /// </summary>
        /// <param name="loadPrefab">UI预制体</param>
        /// <param name="parents">父节点</param>
        /// <returns>加载完成的GameObject</returns>
        public GameObject LoadUserInterface(GameObject loadPrefab, Transform parents)
        {
            // 克隆物件 并自动创建至场景中
            GameObject tempUIRes = GameObject.Instantiate(loadPrefab, parents);
            // 属性更改
            tempUIRes.name = loadPrefab.name;
            // 完成UI的初始化
            tempUIRes.TryGetComponent(out IUserInterfaceInit iPreInit);
            iPreInit?.Init();

            return tempUIRes;
        }

        #endregion
    }
}

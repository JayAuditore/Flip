using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Flip.UI
{
    public enum GameState
    {
        Running,
        Pause
    }

    public class PauseMenu : MonoBehaviour
    {
        #region 字段

        public GameObject _PauseMenu;      //挂在PauseMenu上
        public PauseMenuButtonPanel PauseMenuButtonPanel;

        #endregion

        #region Unity回调

        //测试添加删除物品
        private void Update()
        {
            BackImageSetActive();
        }

        #endregion

        #region 方法

        //判断背景是否开启
        public void BackImageSetActive()
        {
            if (PauseMenuButtonPanel?.transform.localRotation.eulerAngles.y > 90f)
            {
                PauseMenuButtonPanel?.transform.Find("BackImage").gameObject.SetActive(true);
            }
            else
            {
                PauseMenuButtonPanel?.transform.Find("BackImage").gameObject.SetActive(false);
            }
        }

        public void OnSettingClick()
        {
            //加载设置页面
            PauseMenuButtonPanel.transform.DORotate(new Vector3(0f, 180f, 0f), 3f);
        }

        public void OnMainClick()
        {
            //加载开始页面
            LoadSceneController.Instance.LoadScene(0, null, null);
        }

        public void OnQuitClick()
        {

        }

        //改变游戏的运行状态，运行与暂停
        public void OnResumeClick()
        {
            PauseMenuController.Instance.gameState = GameState.Running;

            _PauseMenu.SetActive(false);
        }

        //在设置页面点击返回
        public void OnSettingBackClick()
        {
            PauseMenuButtonPanel.transform.DORotate(new Vector3(0f, 0f, 0f), 3f);
        }

        #endregion
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Flip.UI.Base;
using Flip.SceneController;

namespace Flip.UI.MainMenu
{
    public class MainPage : BaseUI
    {
        #region 登记的页面

        public OptionPage OptionPage;
        public QuitPage QuitPage;
        public MainMenu MainMenu;
        public SavePage SavePage;

        #endregion

        #region Unity回调

        private void Update()
        {
            ActivateBackground();
        }

        #endregion

        #region 方法

        /// <summary>
        /// 判断是否显示设置页面的背景
        /// </summary>
        private void ActivateBackground()
        {
            if (MainMenu.transform.localRotation.eulerAngles.y > 90f)
            {
                MainMenu.transform.Find("Background").gameObject.SetActive(true);
            }
            else
            {
                MainMenu.transform.Find("Background").gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// 点击继续按钮
        /// </summary>
        public void OnResumeClick()
        {
            SavePage.gameObject.SetActive(true);
            MainMenu.transform.DORotate(new Vector3(0f, 180f, 0f), 2f);
        }

        /// <summary>
        /// 在存档界面点返回
        /// </summary>
        public void OnResumeBackClick()
        {
            MainMenu.transform.DORotate(new Vector3(0f, 0f, 0f), 2f);
            SavePage.gameObject.SetActive(false);
        }

        /// <summary>
        /// 点击选项按钮
        /// </summary>
        public void OnOptionClick()
        {
            OptionPage.gameObject.SetActive(true);
            MainMenu.transform.DORotate(new Vector3(0f, 180f, 0f), 2f);
        }

        /// <summary>
        /// 在选项界面点返回
        /// </summary>
        public void OnOptionBackClick()
        {
            MainMenu.transform.DORotate(new Vector3(0f, 0f, 0f), 2f);
            OptionPage.gameObject.SetActive(false);
        }

        /// <summary>
        /// 点击退出按钮
        /// </summary>
        public void OnQuitClick()
        {
            QuitPage.Show();
        }

        /// <summary>
        /// 点开始游戏
        /// </summary>
        public void OnStartClick()
        {
            LoadSceneController.Instance.LoadScene(1, null, null);
        }

        #endregion
    }
}
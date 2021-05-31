using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Flip.UI
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
            ActivateOptionBackground();
            ActivateResumeBackground();
        }

        #endregion

        #region 方法

        //判断是否显示设置页面的背景
        private void ActivateOptionBackground()
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

        //判断是否显示继续页面的背景
        private void ActivateResumeBackground()
        {
            if (SavePage?.transform.localRotation.eulerAngles.y > 90f)
            {
                SavePage?.transform.Find("Background").gameObject.SetActive(true);
            }
            else
            {
                SavePage?.transform.Find("Background").gameObject.SetActive(false);
            }
        }

        //点击继续按钮
        public void OnResumeClick()
        {
            SavePage.gameObject.SetActive(true);
            MainMenu.transform.DORotate(new Vector3(0f, 180f, 0f), 2f);
        }

        //在存档界面点返回
        public void OnResumeBackClick()
        {
            MainMenu.transform.DORotate(new Vector3(0f, 0f, 0f), 2f);
            SavePage.gameObject.SetActive(false);
        }

        //点击选项按钮
        public void OnOptionClick()
        {
            OptionPage.gameObject.SetActive(true);
            MainMenu.transform.DORotate(new Vector3(0f, 180f, 0f), 2f);
        }

        //在选项界面点返回
        public void OnOptionBackClick()
        {
            MainMenu.transform.DORotate(new Vector3(0f, 0f, 0f), 2f);
            OptionPage.gameObject.SetActive(false);
        }

        //点击退出按钮
        public void OnQuitClick()
        {
            QuitPage.Show();
        }

        //点开始游戏
        public void OnStartClick()
        {
            LoadSceneController.Instance.LoadScene(1, null, null);
        }

        #endregion
    }
}
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

        #endregion

        #region Unity回调

        private void Update()
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

        #endregion

        #region 方法

        //点击选项按钮
        public void OnOptionPageClick()
        {
            MainMenu.transform.DORotate(new Vector3(0f, 180f, 0f), 3f);
        }

        //点击退出按钮
        public void OnQuitPageClick()
        {
            QuitPage.Show();
        }

        //在选项界面点返回
        public void OnOptionPageBackClick()
        {
            MainMenu.transform.DORotate(new Vector3(0f, 0f, 0f), 3f);
        }

        //点开始游戏
        public void OnStartButtonClick()
        {
            LoadSceneController.Instance.LoadScene(1, null, null);
        }

        #endregion
    }
}
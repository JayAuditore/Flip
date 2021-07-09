using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Flip.PlayerControll;
using Flip.SceneController;

namespace Flip.UI.PauseMenu
{
    public enum GameState
    {
        Running,
        Pause
    }

    public class PauseMenu : MonoBehaviour
    {
        #region 字段

        public PlayerInput playerInput;
        private GameState GameState;

        #endregion

        #region Unity回调

        private void Update()
        {
            if (transform.Find("MainPanel").gameObject.activeSelf)
            {
                BackImageSetActive();
            }
            KeyCodeToPause();
        }

        #endregion

        #region 方法

        /// <summary>
        /// 打开暂停菜单
        /// </summary>
        public void KeyCodeToPause()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameState == GameState.Running)
                {
                    playerInput.CanControl(false);
                    transform.Find("Background").gameObject.SetActive(true);
                    transform.Find("MainPanel").gameObject.SetActive(true);
                    GameState = GameState.Pause;
                }
                else if (GameState == GameState.Pause)
                {
                    playerInput.CanControl(true);
                    transform.Find("MainPanel").gameObject.SetActive(false);
                    transform.Find("Background").gameObject.SetActive(false);
                    transform.Find("SettingView").gameObject.SetActive(false);
                    GameState = GameState.Running;
                }
            }
        }

        /// <summary>
        /// 判断背景是否开启
        /// </summary>
        public void BackImageSetActive()
        {
            if (transform.Find("MainPanel").transform.localRotation.eulerAngles.y > 90f)
            {
                transform.Find("MainPanel").transform.Find("BackImage").gameObject.SetActive(true);
            }
            else
            {
                transform.Find("MainPanel").transform.Find("BackImage").gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// 打开设置面板
        /// </summary>
        public void OnSettingClick()
        {
            transform.Find("SettingView").gameObject.SetActive(true);
            transform.Find("MainPanel").transform.DORotate(new Vector3(0f, 180f, 0f), 1.5f);
        }

        /// <summary>
        /// 回到主菜单
        /// </summary>
        public void OnMainClick()
        {
            LoadSceneController.Instance.LoadScene(0, null, null);
        }

        public void OnQuitClick()
        {

        }

        /// <summary>
        /// 改变游戏的运行状态，运行与暂停
        /// </summary>
        public void OnResumeClick()
        {
            playerInput.CanControl(true);
            GameState = GameState.Running;
            transform.Find("SettingView").gameObject.SetActive(false);
            transform.Find("MainPanel").gameObject.SetActive(false);
            transform.Find("Background").gameObject.SetActive(false);
        }

        /// <summary>
        /// 在设置页面点击返回
        /// </summary>
        public void OnSettingBackClick()
        {
            transform.Find("MainPanel").transform.DORotate(new Vector3(0f, 0f, 0f), 1.5f);
        }

        #endregion
    }
}

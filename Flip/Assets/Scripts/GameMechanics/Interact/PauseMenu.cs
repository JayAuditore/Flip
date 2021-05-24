using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace Flip.PauseMenu
{
    public enum GameState
    {
        Running,
        Pause
    }
    public class PauseMenu : MonoBehaviour
    {
        public static PauseMenu _instance;
        public GameState gameState = GameState.Running;
        public GameObject _PauseMenu;      //挂在PauseMenu上
        private void Start()
        {
            _instance = this;
            if (_PauseMenu.activeSelf)
            {
                gameState = GameState.Pause;
            }
            else
            {
                gameState = GameState.Running;
            }
        }
        //测试添加删除物品
        private void Update()
        {
            KeyCodeToPause();
        }
        //改变游戏的运行状态，运行与暂停
        public void Resume()
        {
            //继续游戏
            if (gameState == GameState.Running)
            {
                _PauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
                gameState = GameState.Pause;
            }
            else if (gameState == GameState.Pause)
            {
                _PauseMenu.gameObject.SetActive(false);
                Time.timeScale = 1;
                gameState = GameState.Running;
            }
        }
        public void Setting()
        {
            //加载设置页面
        }
        public void Main()
        {
            //加载开始页面
            //SceneManager.LoadScene();
        }
        public void Quit()
        {
            
        }
        //控制游戏的快捷键
        public void KeyCodeToPause()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _instance.Resume();
            }
            //if (gameState == GameState.Pause)
            //{
            //    if (!Input.GetKey(KeyCode.Mouse0))
            //    {
            //        Input.ResetInputAxes();
            //    }
            //}
        }
    }
}
    